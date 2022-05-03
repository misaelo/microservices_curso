using Lil.Customers.Models;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private List<Customer> _repo = new();

        public CustomersProvider()
        {
            _repo.Add(new Customer { Id = "1", Name = "Rodrigo", City = "Santiago" });
            _repo.Add(new Customer { Id = "2", Name = "Sebastian", City = "Chillan" });
            _repo.Add(new Customer { Id = "3", Name = "Priscila", City = "Los Andes" });
            _repo.Add(new Customer { Id = "4", Name = "Misael", City = "Concepcion" });
        }
        public Task<Customer> GetAsync(string id)
        {
            var customer = _repo.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(customer);
        }
    }
}
