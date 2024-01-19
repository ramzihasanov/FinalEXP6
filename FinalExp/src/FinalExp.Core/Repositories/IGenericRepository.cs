using FinalExp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalExp.Core.Repositories
{
    public  interface IGenericRepository<T> where T : BaseEntity,new()
    {
       
        DbSet<T> Table { get; }
        Task<T> GetByIdAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
        Task Create(T entity);
        void Delete(T entity);
        Task<int> Save();
    }
}
