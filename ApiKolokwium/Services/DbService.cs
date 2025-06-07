using ApiKolokwium.Data;
using ApiKolokwium.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ApiKolokwium.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ClientSubscriptionsResponse> GetClientSubscriptions(int clientId)
    {
        var client = await _context.Clients
            .Where(c => c.IdClient == clientId)
            .Select(c => new ClientSubscriptionsResponse
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Subscriptions = _context.Payments
                    .Where(p => p.IdClient == clientId)
                    .GroupBy(p => new { p.IdSubscription, p.Subscription.Name })
                    .Select(g => new ClientSubscriptionDto
                    {
                        IdSubscription = g.Key.IdSubscription,
                        Name = g.Key.Name,
                        TotalPaidAmount = g.Sum(p => p.Subscription.Price)
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (client == null)
        {
            throw new Exception($"Client with id {clientId} was not found");
        }

        return client;
    }

    public async Task<PaymentResponseDto> AddPayment(AddPaymentDto dto)
    {
   
        var clientExists = await _context.Clients.AnyAsync(c => c.IdClient == dto.IdClient);
        if (!clientExists)
        {
            throw new Exception($"Client with id {dto.IdClient} not found");
        }

      
        var subscription = await _context.Subscriptions
            .FirstOrDefaultAsync(s => s.IdSubscription == dto.IdSubscription);
        if (subscription == null)
        {
            throw new Exception($"Subscription with id {dto.IdSubscription} not found");
        }

       
        if (subscription.EndTime < DateTime.Now)
        {
            throw new Exception("Subscription has expired");
        }

       
        var sale = await _context.Sales
            .Where(s => s.IdClient == dto.IdClient && s.IdSubscription == dto.IdSubscription)
            .OrderByDescending(s => s.CreatedAt)
            .FirstOrDefaultAsync();

        if (sale == null)
        {
            throw new Exception("No sales record found for this subscription");
        }

        DateTime currentPeriodStart = sale.CreatedAt;
        DateTime nextPeriodStart = default;
        bool foundCurrentPeriod = false;

      
        while (!foundCurrentPeriod)
        {
            nextPeriodStart = currentPeriodStart.AddMonths(subscription.RenewalPeriod);

           
            if (DateTime.Now >= currentPeriodStart && DateTime.Now < nextPeriodStart)
            {
                foundCurrentPeriod = true;
            }
            else if (DateTime.Now >= nextPeriodStart)
            {
         
                currentPeriodStart = nextPeriodStart;
            }
            else
            {
             
                throw new Exception("Current date is before subscription start date");
            }
        }

    
        bool alreadyPaid = await _context.Payments
            .AnyAsync(p => p.IdClient == dto.IdClient && 
                           p.IdSubscription == dto.IdSubscription &&
                           p.Date >= currentPeriodStart && 
                           p.Date < nextPeriodStart);

        if (alreadyPaid)
        {
            throw new Exception("Subscription for this period has already been paid");
        }
        
        double expectedAmount = subscription.Price;
        
        var activeDiscount = await _context.Discounts
            .Where(d => d.IdSubscription == dto.IdSubscription && 
                        (d.DateFrom == null || d.DateFrom <= DateTime.Now) && 
                        (d.DateTo == null || d.DateTo >= DateTime.Now))
            .OrderByDescending(d => d.Value)
            .FirstOrDefaultAsync();

        if (activeDiscount != null)
        {
        
            expectedAmount = expectedAmount * (1 - activeDiscount.Value / 100.0);
        }

      
        if (Math.Abs(Math.Round(dto.Payment, 2) - Math.Round(expectedAmount, 2)) > 0.01)
        {
            throw new Exception($"Payment amount is incorrect. Expected: {expectedAmount}, Provided: {dto.Payment}");
        }

      
        var payment = new Models.Payment
        {
            IdClient = dto.IdClient,
            IdSubscription = dto.IdSubscription,
            Date = DateTime.Now
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();


        return new PaymentResponseDto
        {
            IdPayment = payment.IdPayment
        };
    }
}