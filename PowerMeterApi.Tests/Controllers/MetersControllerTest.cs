using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PowerMeterApi.Controllers;
using PowerMeterApi.Models;
using PowerMeterApi.Services;
using Xunit;

namespace PowerMeterApi.Tests
{
    public class MetersControllerTest
    {
        private readonly MeterController meterController;

        public MetersControllerTest() 
        {
            var mockMeterService = new Mock<IMeterService>();
            mockMeterService.Setup(m => m.FindById("1")).Returns(new Meter("1"));
            this.meterController = new MeterController(mockMeterService.Object);
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
