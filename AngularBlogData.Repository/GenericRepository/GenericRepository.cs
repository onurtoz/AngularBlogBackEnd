using AngularBlog.Data.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlogData.Repository.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _dbcontext;
        protected int _process;
        protected List<T> list;

        public GenericRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public virtual int Count()
        {
            return _dbcontext.Set<T>().Count();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }


        public virtual async Task<ICollection<T>> GetAllAsyn()
        {

            return await _dbcontext.Set<T>().ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetPageSize(int pageSize, int pageNumber)
        {


            return _dbcontext.Set<T>().Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }


        public virtual IEnumerable<T> FindFilterAndPagging(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize)
        {
            IEnumerable<T> query = null;

            if (predicate != null)
            {
                query = _dbcontext.Set<T>().Skip(pageNumber * pageSize).Where(predicate).Take(pageSize);
            }
            else
            {
                query = _dbcontext.Set<T>().Skip(pageNumber * pageSize).Take(pageSize);
            }


            return query;

        }

        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }
            if (where != null) {
                list = queryable.AsNoTracking().Where(where).ToList<T>();
            }
            else
            {
                list = queryable.AsNoTracking().ToList<T>();
            }

         

            return list;

        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbcontext.Set<T>();
        }

        public virtual IList<T> FindFilterIncludePropertiesAndPagging(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] navigationProperties)
        {

            IQueryable<T> queryable = GetAll();

            if (navigationProperties != null)
            {
                foreach (Expression<Func<T, object>> includeProperty in navigationProperties)
                {

                    queryable = queryable.Include<T, object>(includeProperty);
                }
                if (predicate != null)
                {
                    list = queryable.Where(predicate).Skip(pageNumber * pageSize).Take(pageSize).ToList<T>();

                }
                else
                {
                    list = queryable.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList<T>();
                }

            }

            return list;
        }

        public virtual IList<T> FindProperties(Func<T, bool> where, Expression<Func<T, object>> navigationProperties)
        {
            IQueryable<T> queryable = GetAll();
            queryable = queryable.Include<T, object>(navigationProperties);
            if (where != null)
            {
                list = queryable.AsNoTracking().Where(where).ToList<T>();
            }
            else
            {
                list = queryable.AsNoTracking().ToList<T>();
            }



            return list;
        }
    }
}
