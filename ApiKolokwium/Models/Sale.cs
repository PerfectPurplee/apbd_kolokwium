using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKolokwium.Models;

[Table("Sale")]
public class Sale
{
    [Key]
    public int IdSale { get; set; }
    public DateTime CreatedAt { get; set; }
    
    [ForeignKey(nameof(Client))]
    public int IdClient { get; set; }
    [ForeignKey(nameof(Subscription))]
    public int IdSubscription { get; set; }

    public Client Client { get; set; } = null!;
    public Subscription Subscription { get; set; } = null!;
    
    public ICollection<Subscription> Subscriptions { get; set; } = null!;
}