using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTests
    {
        [TestMethod]
        public void GetAsyncReturnOK()
        {
            var customersProvider = new CustomersProvider();
            var customersController = new CustomersController(customersProvider);

           var result = customersController.GetAsync("1");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnNotFound()
        {
            var customersProvider = new CustomersProvider();
            var customersController = new CustomersController(customersProvider);

            var result = customersController.GetAsync("99");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}