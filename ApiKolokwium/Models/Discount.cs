using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiKolokwium.Models;

[Table("Discount")]
public class Discount
{
    [Key]
    public int IdDiscount { get; set; }
    
    public int Value {get; set;}
    
    [ForeignKey(nameof(Subscription))]
    public int IdSubscription { get; set; }
    
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    
    
}