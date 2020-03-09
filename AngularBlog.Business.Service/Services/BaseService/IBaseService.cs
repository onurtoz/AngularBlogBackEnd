using AngularBlog.Business.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Business.Service.Services.BaseService
{
    public interface IBaseService<T> where T : class
    {
        ServiceResponse<List<T>> GetAllIncludeList();
        ServiceResponse<T> GetIncludePropertyById(int id);
        ServiceResponse<List<T>> GetIncludePropertyPaggingList(int pagenumber, int pagesize);
    }
}
