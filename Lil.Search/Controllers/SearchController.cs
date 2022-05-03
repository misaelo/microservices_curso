using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly IProductsService productsService;
        private readonly ISalesService salesService;

        public SearchController(ICustomersService _customersService, IProductsService _productsService, ISalesService _salesService)
        {
            customersService = _customersService;
            productsService = _productsService;
            salesService = _salesService;
        }

        [HttpGet("Customers/{customerID}")]
        public async Task<IActionResult> SearchAsync(string customerID)
        {
            if (string.IsNullOrWhiteSpace(customerID))
                return BadRequest();

            try
            {
                var customer = await customersService.GetAsync(customerID);
                var sales = await salesService.GetAsync(customerID);               

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await productsService.GetAsync(item.ProductId);

                        item.Product = product;
                    }
                }
                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
