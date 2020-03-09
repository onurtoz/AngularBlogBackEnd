using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngularBlog.Business.Model.Model;
using AngularBlog.Business.Model.Response;
using AngularBlog.Business.Service.Services.ArticleService;
using AngularBlog.Data.Model.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApiWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("[action]")]
        public ServiceResponse<List<ArticleModel>> GetArticles(int page, int pageSize = 5)
        {
            Thread.Sleep(2000);
            return _articleService.GetIncludePropertyPaggingList(page, pageSize);
        }

        [HttpGet("{id}")]
        //[Route("[action]")]
        public ServiceResponse<ArticleModel> GetArticle(int id)
        {
            Thread.Sleep(2000);
            return _articleService.GetIncludePropertyById(id);
        }



        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
