using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
