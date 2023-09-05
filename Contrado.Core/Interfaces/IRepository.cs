using Contrado.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Core.Interfaces
{
   public interface IRepository<T> where T : BaseEntity
    {
        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        Task<T> GetById(object id);

        /// <summary>
        /// Get first or default entity
        /// </summary>
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task Insert(T entity);

        /// <summary>
        /// Insert entity and return id
        /// </summary>
        /// <param name="entity">Entity</param>
        Task<int> InsertAndGetId(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task InsertAll(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task UpdateAll(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        Task Delete(object id);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        Task Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        Task DeleteAll(IEnumerable<T> entities);

        /// <summary>
        /// Get all entities
        /// </summary>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get conditional entities
        /// </summary>
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get entity count
        /// </summary>
        Task<int> CountAll();

        /// <summary>
        /// Get conditional entity count
        /// </summary>
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        #endregion
    }
}
