using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;
using System.Linq;

namespace WebApplication2.Contracts
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
