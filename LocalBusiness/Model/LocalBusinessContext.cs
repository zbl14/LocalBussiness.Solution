using Microsoft.EntityFrameworkCore;

namespace LocalBusiness.Models
{
  public class LocalBusinessContext : DbContext
  {
    public LocalBusinessContext(DbContextOptions<LocalBusinessContext> options)
        : base(options)
    {
    }

    public DbSet<Business> Business { get; set;}
  }
}