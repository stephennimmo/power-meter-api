using Microsoft.EntityFrameworkCore;

namespace PowerMeterApi.Models
{
    public class MeterDbContext : DbContext
    {
        public virtual DbSet<Meter> Meters { get; set; }

        public MeterDbContext()
        {
        }
        public MeterDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("meter_db");
        }
    }
}