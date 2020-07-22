using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PowerMeterApi.Controllers;
using PowerMeterApi.Models;
using PowerMeterApi.Services;
using Xunit;

namespace PowerMeterApi.Tests
{
    public class MetersControllerTest : AbstractTest
    {
        private readonly MeterController meterController;

        public MetersControllerTest() 
        {
            var collection = new List<Meter>
            {
                new Meter { MeterId = "1" }
            };
            var meterDbSet = this.CreateDbSet(collection.AsQueryable());
            var stubContext = new Mock<MeterDbContext>();
            stubContext.Setup(o => o.Meters).Returns(meterDbSet);
            var meterService = new MeterService(stubContext.Object);
            this.meterController = new MeterController(meterService);
        }

        [Fact]
        public void FindById()
        {
            ActionResult<Meter> actionResult = this.meterController.GetById("1");
            Meter meter = actionResult.Value;
            Assert.Equal("1", meter.MeterId);
        }
    }
}
