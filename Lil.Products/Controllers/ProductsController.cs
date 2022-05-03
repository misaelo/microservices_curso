using Lil.Products.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider provider;
        
        public ProductsController(IProductsProvider _provider)
        {
            provider = _provider;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await provider.GetAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
