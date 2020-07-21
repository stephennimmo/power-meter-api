using Microsoft.EntityFrameworkCore;

namespace PowerMeterApi.Models
{
    public class MeterDbContext : DbContext 
    {
        public DbSet<Meter> Meters { get; set; }

        public MeterDbContext(DbContextOptions<MeterDbContext> options) : base(options)
        {
        }
    }
}