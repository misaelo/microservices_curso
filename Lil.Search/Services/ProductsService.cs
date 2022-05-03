using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ProductsService(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }

        public async Task<Product> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productsService");
            var response = await client.GetAsync($"api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Product = JsonConvert.DeserializeObject<Product>(content);
                return Product;
            }
            return null;
        }
    }
}
