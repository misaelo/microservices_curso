using Lil.Search.Models;

namespace Lil.Search.Interfaces
{
    public interface ISalesService
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
