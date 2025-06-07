using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKolokwium.Models;

[Table("Client")]
public class Client
{
    [Key] public int IdClient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = null!;
    [MaxLength(100)] public string LastName { get; set; } = null!;
    [MaxLength(100)] public string Email { get; set; } = null!;
    [MaxLength(100)] public string Phone { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Sale> Orders { get; set; } = new List<Sale>();
}