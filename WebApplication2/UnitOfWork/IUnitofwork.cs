using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithRepository.Repositories;

namespace UnitOfWorkWithRepository.UnitOfWork
{
    public interface IUnitofwork<TContext> where TContext : DbContext
    {
        void Commit();
        void Rollback();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
