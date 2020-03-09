using AngularBlog.Data.Model.Entities;
using AngularBlogData.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlogData.Repository.ArticleRepository
{
   public interface IArticleRepository : IGenericRepository<Article>
    {
    }
}
