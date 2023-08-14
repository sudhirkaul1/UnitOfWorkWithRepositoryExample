using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

using System.Linq;
using WebApplication2.Data;
using WebApplication2.UnitOfWork;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> 
        where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        
        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<bool> AddAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return true;
        }
    }
}
