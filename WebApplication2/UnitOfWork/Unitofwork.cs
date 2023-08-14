using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.Validation;
using WebApplication2.Data;
using WebApplication2.Repositories;


namespace WebApplication2.UnitOfWork;
public class UnitOfWork<TContext> : IUnitofwork<TContext>, IDisposable
    where TContext : AppDbContext
{
    private readonly TContext _dbContext;
    private bool _disposed;
    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Commit()
    {
        _dbContext.SaveChanges();
    }
    public void Rollback()
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
    public IGenericRepository<T> Repository<T>() where T : class
    {
        return new GenericRepository<T>(_dbContext);
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
