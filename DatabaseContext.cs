
using ApiKolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiKolokwium.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Payment> Payments { get; set; }  // Zmienione z "Statuses"
    public DbSet<Discount> Discounts { get; set; }  // Zmienione z "Products"
    public DbSet<Sale> Sales { get; set; }  // Zmienione z "Orders"
    public DbSet<Subscription> Subscriptions { get; set; }  // Zmienione z "ProductOrders"
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Poprzednia konfiguracja pozostaje bez zmian
        base.OnModelCreating(modelBuilder);
    }
}