using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace PowerMeterApi.Tests 
{
    public abstract class AbstractTest 
    {
        public DbSet<T> CreateDbSet<T>(IQueryable<T> collection) where T:class
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