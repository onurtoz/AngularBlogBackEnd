using AngularBlog.Data.Model.Entities;
using AngularBlog.Data.Model.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationCategoryConfig());
            builder.ApplyConfiguration(new ApplicationArticleConfig());
            builder.ApplyConfiguration(new ApplicationCommentConfig());
        }
    }
}
