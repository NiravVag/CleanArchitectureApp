using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly ApplicationDBContext _contex;
        public GenericRepositoryAsync(ApplicationDBContext context)
        {
            _contex = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _contex.AddAsync(entity).ConfigureAwait(false);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _contex.Remove(entity);
            await _contex.SaveChangesAsync();
        }

        public virtual async Task<T> FindByCondition(int id)
        {
            return await _contex.Set<T>().FindAsync(id);

        }

        public virtual IQueryable<T> GetAllAsync()
        {
            return _contex.Set<T>();
        }

        public virtual async Task<IQueryable<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return (await _contex.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false)).AsQueryable();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _contex.Entry(entity).State = EntityState.Modified;
                await _contex.SaveChangesAsync();
            }
            return entity;
        }
    }
}
