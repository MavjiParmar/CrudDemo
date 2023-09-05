using Contrado.Core.Entities;
using Contrado.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Infastructure.Data.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        protected readonly AppDbContext _appDbContext;

        protected DbSet<T> _entities;

        #endregion

        #region Constructor

        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public async Task<T> GetById(object id)
        {
            return await Entities.FindAsync(id);
        }




        /// <summary>
        /// Inserts entity and returns inserted id
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Inserted Id</returns>
        public async Task<int> InsertAndGetId(T entity)
        {
            await Entities.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Get first or default entity
        /// </summary>
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task Insert(T entity)
        {
            await Entities.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }


        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task InsertAll(IEnumerable<T> entities)
        {
            await Entities.AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task Update(T entity)
        {
            Entities.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task UpdateAll(IEnumerable<T> entities)
        {
            Entities.UpdateRange(entities);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        public async Task Delete(object id)
        {
            var entity = await Entities.FindAsync(id);
            await Delete(entity);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task Delete(T entity)
        {
            Entities.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task DeleteAll(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// All entities
        /// </summary>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        /// <summary>
        /// Get conditional entities
        /// </summary>
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Entities.Where(predicate).OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        /// <summary>
        /// Get entity count
        /// </summary>
        public async Task<int> CountAll()
        {
            return await Entities.CountAsync();
        }

        /// <summary>
        /// Get conditional entity count
        /// </summary>
        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await Entities.CountAsync(predicate);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _appDbContext.Set<T>();
                }

                return _entities;
            }
        }

        #endregion
    }
}
