using ApiKolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiKolokwium.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; } 
    public DbSet<Discount> Discounts { get; set; } 
    public DbSet<Sale> Sales { get; set; } 
    public DbSet<Subscription> Subscriptions { get; set; } 

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
}