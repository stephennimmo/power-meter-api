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
    public class MetersControllerTest
    {
        private readonly MeterController meterController;

        public MetersControllerTest() 
        {
            var mockMeterService = new Mock<IMeterService>();
            mockMeterService.Setup(m => m.FindById("1")).Returns(new Meter { MeterId = "1" });
            this.meterController = new MeterController(mockMeterService.Object);
        }

        [Fact]
        public void FindById()
        {
            ActionResult<Meter> actionResult = this.meterController.GetById("1");
            Meter meter = actionResult.Value;
            Assert.Equal("1", meter.MeterId);
        }

        [Fact]
        public void FindById2()
        {
            var expected = "1";
            var collection = new List<Meter>
            {
                new Meter { MeterId = "1" }
            };
            var meterDbSet = CreateDbSet(collection.AsQueryable());
            var stubContext = new Mock<MeterDbContext>();
            stubContext.Setup(o => o.Meters).Returns(meterDbSet);
            var sut = new MeterService(stubContext.Object);
            //Act
            var actual = sut.FindById("1");
            //Assert
            Assert.Equal(expected, actual.MeterId);
        }

        private DbSet<T> CreateDbSet<T>(IQueryable<T> collection) where T:class
        {
            var stubDbSet = new Mock<DbSet<T>>();
            stubDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(collection.Provider);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(collection.Expression);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(collection.ElementType);
            stubDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(collection.GetEnumerator());
            return stubDbSet.Object;
        }

    }
}
