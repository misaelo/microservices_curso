using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomersService(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        public async Task<Customer> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("customersService");
            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;
            }
            return null;
        }
    }
}
