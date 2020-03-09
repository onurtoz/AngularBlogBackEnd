using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlogData.Repository.GenericRepository
{
   public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsyn();
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        T Get(int id);
        IList<T> FindProperties(Func<T, bool> where, Expression<Func<T, object>> navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> GetPageSize(int pageSize, int pageNumber);
        IEnumerable<T> FindFilterAndPagging(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
        IList<T> FindFilterIncludePropertiesAndPagging(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] navigationProperties);
        int Count();


    }
}
