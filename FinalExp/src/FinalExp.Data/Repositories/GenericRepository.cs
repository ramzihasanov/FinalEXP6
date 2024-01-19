using FinalExp.Core.Entities;
using FinalExp.Core.Repositories;
using FinalExp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FinalExp.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public DbSet<T> Table => _appDbContext.Set<T>();

        public async Task Create(T entity)
        {
           await Table.AddAsync(entity);
        }

        public  void Delete(T entity)
        {
             Table.Remove(entity);
        }


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null
                        ? await query.Where(expression).ToListAsync()
                        : await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null
                    ? await query.Where(expression).FirstOrDefaultAsync()
                    : await query.FirstOrDefaultAsync();
        }

        public async Task<int> Save()
        {
           return await _appDbContext.SaveChangesAsync();
        }
        private IQueryable<T> GetQuery(string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }
    }
}
