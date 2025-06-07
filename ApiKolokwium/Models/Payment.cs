using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKolokwium.Models;

[Table("Payment")]
public class Payment
{
    [Key] public int IdPayment { get; set; }
    public DateTime Date { get; set; }

    [ForeignKey(nameof(Client))] public int IdClient { get; set; }

    [ForeignKey(nameof(Subscription))] public int IdSubscription { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual Subscription Subscription { get; set; } = null!;
}