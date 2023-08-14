using Microsoft.EntityFrameworkCore;
using WebApplication2.Repositories;

namespace WebApplication2.UnitOfWork
{
    public interface IUnitofwork<TContext> where TContext : DbContext
    {
        void Commit();
        void Rollback();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
