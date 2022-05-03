using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
