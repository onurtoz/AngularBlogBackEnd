using AngularBlog.Data.Model.Data;
using AngularBlog.Data.Model.Entities;
using AngularBlogData.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularBlogData.Repository.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public override Task<ICollection<Category>> GetAllAsyn()
        {
            return base.GetAllAsyn();
        }

        public override Task<Category> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override IQueryable<Category> GetAll()
        {
            return base.GetAll();
        }

        public override Category Get(int id)
        {
            return base.Get(id);
        }
    }
}
