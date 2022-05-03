using Lil.Sales.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider provider;

        public SalesController(ISalesProvider _provider)
        {
            provider = _provider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var result = await provider.GetAsync(customerId);
            if (result != null && result.Any())
                return Ok(result);

            return NotFound();
        }
    }
}
