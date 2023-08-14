using UnitOfWorkWithRepository.Models;
using UnitOfWorkWithRepository.Repositories;

namespace UnitOfWorkWithRepository.EntityRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerByName(string name);
    }
}
