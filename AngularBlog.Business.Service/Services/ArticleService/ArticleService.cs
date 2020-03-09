using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngularBlog.Business.Model.Model;
using AngularBlog.Business.Model.Response;
using AngularBlog.Data.Model.Entities;
using AngularBlogData.Repository.ArticleRepository;

namespace AngularBlog.Business.Service.Services.ArticleService
{
    public class ArticleService : IArticleService
    {

        private readonly IArticleRepository _articleRepository;


        private List<ArticleModel> _articleModels = new List<ArticleModel>();
        private CategoryModel _categoryModel = new CategoryModel();
        private ArticleModel articleModel = new ArticleModel();
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public ServiceResponse<List<ArticleModel>> GetAllIncludeList()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ArticleModel> GetIncludePropertyById(int id)
        {
            var response = new ServiceResponse<ArticleModel>();
            IList<Article> articles = _articleRepository.FindProperties(c=>c.ArticleID.Equals(id),x=>x.Category);

            int count = 0;

            foreach (var article in articles)
            {
                articleModel.ArticleID = article.ArticleID;
                articleModel.CategoryID = article.CategoryID;
                articleModel.CommentCount = article.CommentCount;
                articleModel.ContentMain = article.ContentMain;
                articleModel.ContentSummary = article.ContentSummary;
                articleModel.Picture = article.Picture;
                articleModel.Publish_Date = article.Publish_Date;
                articleModel.Title = article.Title;
                articleModel.ViewCount = article.ViewCount;
                _categoryModel.CategoryID = article.Category.CategoryId;
                _categoryModel.CategoryName = article.Category.CategoryName;
                articleModel.Category = _categoryModel;
                count++;
            }

            response.Entity = articleModel;
            response.Count = count;
            return response;
        }

        public ServiceResponse<List<ArticleModel>> GetIncludePropertyPaggingList(int pagenumber, int pagesize)
        {
            var response = new ServiceResponse<List<ArticleModel>>();
            IEnumerable<Article> articles = _articleRepository.FindFilterIncludePropertiesAndPagging(null, pagenumber, pagesize, e => e.Category);
            int count = 0;


            foreach (var article in articles)
            {

                _categoryModel.CategoryID = article.Category.CategoryId;
                _categoryModel.CategoryName = article.Category.CategoryName;
                _articleModels.Add(new ArticleModel
                {
                    ArticleID = article.ArticleID,
                    CategoryID = article.CategoryID,
                    Title = article.Title,
                    CommentCount = article.CommentCount,
                    ContentSummary = article.ContentSummary,
                    ContentMain = article.ContentMain,
                    Publish_Date = article.Publish_Date,
                    ViewCount = article.ViewCount,
                    Picture = article.Picture,
                    Category = _categoryModel
                });
                _categoryModel = new CategoryModel();
                count++;
            }

            int TotalCount = _articleRepository.Count();

            response.TotalCount = TotalCount;
            response.Entity = _articleModels;
            response.Count = count;
            return response;
        }
    }
}
