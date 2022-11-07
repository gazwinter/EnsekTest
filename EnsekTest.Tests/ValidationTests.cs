using EnsekTest.Data.Entities;
using EnsekTest.Services.Implementations;
using EnsekTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EnsekTest.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private  IMeterReadingService _service { get; set; }
        private Mock<EnsekTestContext> _context { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new Mock<EnsekTestContext>();
        }

        [TestMethod]
        public void IncorrectAccountId_ShouldReturn_False()
        {
            //var mockAccountsDbSet = new Mock<DbSet<Accounts>>();
            //_context
            //    .Setup(s => s.Accounts).Returns(mockAccountsDbSet.Object);
            //_service = new MeterReadingService(_context.Object);

            //var result = _service.ValidateAccountId(1, out int accountId);

            //Assert.IsFalse(result);
            //Assert.AreEqual(-1, accountId);
        }

        [TestMethod]
        public void NonInteger_AccountId_ShouldReturn_False()
        {
            //Implement UNIT TESTS
        }

        [TestMethod]
        public void Valid_AccountId_ShouldReturn_True()
        {
            //Implement UNIT TESTS
        }

        [TestMethod]
        public void Valid_Date_ShouldReturn_True()
        {
            var date = "01/01/2022 00:00:00";
            _service = new MeterReadingService(_context.Object);

            var result = _service.ValidateDate(date, out DateTime readDate);
            Assert.IsTrue(result);
            Assert.AreEqual(DateTime.Parse(date), readDate);
        }

        [TestMethod]
        public void FutureDate_ShouldReturn_False()
        {
            var date = "01/01/2025 00:00:00";
            _service = new MeterReadingService(_context.Object);

            var result = _service.ValidateDate(date, out DateTime readDate);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InValid_DateString_ShouldReturn_False()
        {
            var date = "13/13/2025 00:00:00";
            _service = new MeterReadingService(_context.Object);

            var result = _service.ValidateDate(date, out DateTime readDate);
            Assert.IsFalse(result);
        }
    }
}