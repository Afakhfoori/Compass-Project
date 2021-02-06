using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Compass.Domain;
using Compass.Repository;
using Microsoft.EntityFrameworkCore;

namespace Compass.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CompassContext _context;
        protected IQueryable<TEntity> _dbQuery;

        public Repository(CompassContext context)
        {
            _context = context;
            _dbQuery = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                _dbQuery = _dbQuery.Include<TEntity, object>(navigationProperty);

            return _dbQuery
                .AsNoTracking()
                .ToList<TEntity>();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                _dbQuery = _dbQuery.Include<TEntity, object>(navigationProperty);

            return await _dbQuery
                            .AsNoTracking()
                            .ToListAsync<TEntity>();
        }


        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                _dbQuery = _dbQuery.Include<TEntity, object>(navigationProperty);

            return _dbQuery.SingleOrDefault(where); //Apply where clause
        }

        public async virtual Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                _dbQuery = _dbQuery.Include<TEntity, object>(navigationProperty);

            return await _dbQuery.FirstOrDefaultAsync(where);
        }
    }

}
