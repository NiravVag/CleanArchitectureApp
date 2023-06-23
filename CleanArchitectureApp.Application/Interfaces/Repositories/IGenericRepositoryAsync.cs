using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        public IQueryable<T> GetAllAsync();

        public Task<T> FindByCondition(int id);

        public Task<IQueryable<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

        public Task<T> AddAsync(T entity);

        public Task<T> UpdateAsync(T entity);

        public Task DeleteAsync(T entity);
    }
}
