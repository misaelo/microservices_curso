using Lil.Customers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider provider;

        public CustomersController(ICustomersProvider _provider)
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
