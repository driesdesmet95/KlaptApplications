using Klapt.Event.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Klapt.Event.EfCore
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        // Get by Id with optional includes
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

        // Get all with optional includes
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        // Add entity
        Task AddAsync(T entity);

        // Update entity
        Task Update(T entity);

        // Remove entity
        Task Remove(T entity);

    }
}
