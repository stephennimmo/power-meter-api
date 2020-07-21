using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerMeterApi.Models;
using PowerMeterApi.Services;

namespace PowerMeterApi.Controllers
{
    [ApiController]
    [Route("api/meters")]
    public class MetersController : ControllerBase
    {
        private readonly IMeterService meterService;

        public MetersController(IMeterService meterService)
        {
            this.meterService = meterService;
        }

        [HttpGet("{meterId}")]
        public IActionResult GetById(string meterId)
        {
            Meter meter = meterService.FindById(meterId);
            if (meter == null)
            {
                return NotFound();
            }
            return Ok(meter);
        }
    }
}
