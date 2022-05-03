using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Tests
{
    [TestClass]
    public class SalesTests
    {
        [TestMethod]
        public void GetAsyncReturnOK()
        {
            var SalesProvider = new SalesProvider();
            var SalesController = new SalesController(SalesProvider);

            var result = SalesController.GetAsync("1");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnNotFound()
        {
            var SalesProvider = new SalesProvider();
            var SalesController = new SalesController(SalesProvider);

            var result = SalesController.GetAsync("99");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}