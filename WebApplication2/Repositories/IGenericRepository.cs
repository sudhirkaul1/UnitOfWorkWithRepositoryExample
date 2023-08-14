using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication2.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> AddAsync(T entity);
    }
}
