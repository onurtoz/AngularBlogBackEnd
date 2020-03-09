using AngularBlog.Business.Model.Model;
using AngularBlog.Business.Model.Response;
using AngularBlog.Business.Service.Services.BaseService;
using AngularBlog.Data.Model.Entities;
using AngularBlogData.Repository.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Business.Service.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private List<CategoryModel> _categoryModels = new List<CategoryModel>();
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceResponse<List<CategoryModel>> GetAllIncludeList()
        {
            var response = new ServiceResponse<List<CategoryModel>>();
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            int count = 0;
            foreach (var category in categories)
            {
                _categoryModels.Add(new CategoryModel()
                {
                    CategoryID = category.CategoryId,
                    CategoryName = category.CategoryName
                });
                count++;
            }
            response.Entity = _categoryModels;
            response.Count = count;
            return response;
        }

        public ServiceResponse<CategoryModel> GetIncludePropertyById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<CategoryModel>> GetIncludePropertyPaggingList(int pagenumber, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
