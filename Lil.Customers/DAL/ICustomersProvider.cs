using Lil.Customers.Models;

namespace Lil.Customers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
    }
}
