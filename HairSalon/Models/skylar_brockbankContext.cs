using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class skylar_brockbankContext : DbContext
  {
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Client> Clients { get; set; }

    public skylar_brockbankContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}