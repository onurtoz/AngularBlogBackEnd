using AngularBlog.Data.Model.Data;
using AngularBlog.Data.Model.Entities;
using AngularBlogData.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AngularBlogData.Repository.ArticleRepository
{
    public class ArticleRepository: GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IList<Article> FindFilterIncludePropertiesAndPagging(Expression<Func<Article, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<Article, object>>[] navigationProperties)
        {
            return base.FindFilterIncludePropertiesAndPagging(predicate, pageNumber, pageSize, navigationProperties);
        }
        public override IList<Article> GetList(Func<Article, bool> where, params Expression<Func<Article, object>>[] includeProperties)
        {
            return base.GetList(where, includeProperties);
        }

        public override int Count()
        {
            return base.Count();
        }

        public override Article Get(int id)
        {
            return base.Get(id);
        }

        public override IList<Article> FindProperties(Func<Article, bool> where, Expression<Func<Article, object>> navigationProperties)
        {
            return base.FindProperties(where, navigationProperties);
        }
    }
}
