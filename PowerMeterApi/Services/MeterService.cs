using System.Collections.Generic;
using System.Linq;
using PowerMeterApi.Models;

namespace PowerMeterApi.Services 
{
    public interface IMeterService
    {
        List<Meter> FindAll();
        Meter FindById(string meterId);
    }
    public class MeterService : IMeterService
    {
        private readonly MeterDbContext dbContext;

        public MeterService(MeterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Meter> FindAll() {
            return this.dbContext.Meters.ToList();
        }

        public Meter FindById(string meterId) {
            return this.dbContext.Meters.FirstOrDefault(m => m.MeterId == meterId);
        }

    }
}