using Microsoft.EntityFrameworkCore;

namespace PowerMeterApi.Models
{
    public class MeterDbContext : DbContext
    {

        public MeterDbContext() 
        {
            
        }
        public MeterDbContext(DbContextOptions<MeterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meter> Meters { get; set; }
        
    }
}