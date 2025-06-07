using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiKolokwium.Models;

[Table("Subscription")]

public class Subscription

{
    [Key]
    public int IdSubscription { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    public int RenewalPeriod { get; set; }
    
    public DateTime EndTime { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double Price { get; set; }

 
}