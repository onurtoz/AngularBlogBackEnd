using AngularBlog.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Mapping
{
    public class ApplicationArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleID);
            builder.Property(x => x.ArticleID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryID).IsRequired();
            builder.Property(x=>x.ContentMain).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ContentSummary).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryID);
            builder.HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
            builder.ToTable("Article");
        }
    }
}
