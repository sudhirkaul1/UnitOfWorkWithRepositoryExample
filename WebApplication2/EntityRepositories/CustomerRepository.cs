using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithRepository.Data;
using UnitOfWorkWithRepository.Models;
using UnitOfWorkWithRepository.Repositories;
using System.Linq;

namespace UnitOfWorkWithRepository.EntityRepositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(
            AppDbContext context
            ) : base( context )
        {
            _appDbContext = context;            
        }

        public async Task<IEnumerable<Customer>> GetCustomerByName(string name )
        {
            var customers =  _appDbContext.Set<Customer>()
                            .Where( x => x.Name.StartsWith(name));

            return await customers.ToListAsync();
        }
       
    }
}
