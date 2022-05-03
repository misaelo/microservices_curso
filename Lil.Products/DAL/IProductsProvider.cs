using Lil.Products.Models;

namespace Lil.Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string id);
    }
}
