using Microsoft.EntityFrameworkCore;

namespace LocalBusiness.Models
{
  public class LocalBusinessContext : DbContext
  {
    public LocalBusinessContext(DbContextOptions<LocalBusinessContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Business>()
          .HasData(
              new Business { BusinessId = 1, Name = "Pho Love", Type = "Restaurant", Phone = "6267778888", Address = "1 Technology Dr, Irvine, Ca 92618" },
              new Business { BusinessId = 2, Name = "Four Sea Restaurant", Type = "Restaurant", Phone = "4434425678", Address = "123 Alton Parkway, Irvine, Ca 92618" },
              new Business { BusinessId = 3, Name = "Duke Bakery", Type = "Restaurant", Phone = "8883332345", Address = "45 Jaboree Road, Irvine, Ca 92618" },
              new Business { BusinessId = 4, Name = "TjMax", Type = "Shop", Phone = "9098885643", Address = "166 Alliance Ave, Tustin Ca 92780" },
              new Business { BusinessId = 5, Name = "Mayce", Type = "Shop", Phone = "9092226789", Address = "678 Tomson Street, Tustin Ca 92780" }
          );
    }

    public DbSet<Business> Business { get; set;}
  }
}