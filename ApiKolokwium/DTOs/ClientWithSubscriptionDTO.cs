namespace ApiKolokwium.Models.DTOs;

public class ClientSubscriptionsResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public IEnumerable<ClientSubscriptionDto> Subscriptions { get; set; } = null!;
}

public class ClientSubscriptionDto
{
    public int IdSubscription { get; set; }
    public string Name { get; set; } = null!;
    public double TotalPaidAmount { get; set; }
}