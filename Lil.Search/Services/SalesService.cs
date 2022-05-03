using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public SalesService(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = httpClientFactory.CreateClient("salesService");
            var response = await client.GetAsync($"api/Sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);
                return Orders;
            }
            return null;
        }
    }
}
