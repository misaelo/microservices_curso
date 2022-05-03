using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Products.Tests
{
    [TestClass]
    public class ProductsTests
    {
        [TestMethod]
        public void GetAsyncReturnOK()
        {
            var ProductsProvider = new ProductsProvider();
            var ProductsController = new ProductsController(ProductsProvider);

            var result = ProductsController.GetAsync("1");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnNotFound()
        {
            var ProductsProvider = new ProductsProvider();
            var ProductsController = new ProductsController(ProductsProvider);

            var result = ProductsController.GetAsync("99");

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}