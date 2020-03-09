using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ContentMain { get; set; }
        public string ContentSummary { get; set; }
        public DateTime Publish_Date { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
        public string Picture { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
