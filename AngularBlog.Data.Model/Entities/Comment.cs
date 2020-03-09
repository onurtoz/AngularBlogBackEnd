using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public DateTime Publish_Date { get; set; }
        public Article Article { get; set; }
    }
}
