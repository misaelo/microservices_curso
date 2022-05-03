using Lil.Search.Models;

namespace Lil.Search.Interfaces
{
    public interface IProductsService
    {
        Task<Product> GetAsync(string id);
    }
}
