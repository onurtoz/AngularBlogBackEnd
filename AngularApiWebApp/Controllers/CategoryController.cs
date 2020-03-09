using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngularBlog.Business.Model.Model;
using AngularBlog.Business.Model.Response;
using AngularBlog.Business.Service.Services.CategoryService;
using AngularBlog.Data.Model.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApiWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("[action]")]
        public ServiceResponse<List<CategoryModel>> GetCategory()
        {
            Thread.Sleep(2000);
            return _categoryService.GetAllIncludeList();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public string GetCategoryById(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
