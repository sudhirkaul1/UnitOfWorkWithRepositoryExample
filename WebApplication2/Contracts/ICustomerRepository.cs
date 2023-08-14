using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerByName(string name);
    }
}
