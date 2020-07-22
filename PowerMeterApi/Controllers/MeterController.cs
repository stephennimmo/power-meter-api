using Microsoft.AspNetCore.Mvc;
using PowerMeterApi.Models;
using PowerMeterApi.Services;

namespace PowerMeterApi.Controllers
{
    [ApiController]
    [Route("api/meters")]
    public class MeterController : ControllerBase
    {
        private readonly IMeterService meterService;

        public MeterController(IMeterService meterService)
        {
            this.meterService = meterService;
        }

        [HttpGet("{meterId}")]
        public ActionResult<Meter> GetById(string meterId)
        {
            Meter meter = meterService.FindById(meterId);
            if (meter == null)
            {
                return NotFound();
            }
            return meter;
        }
    }
}
