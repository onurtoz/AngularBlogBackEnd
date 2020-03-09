using AngularBlog.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Mapping
{
    public class ApplicationCommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.CommentId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ArticleId).IsRequired();
            builder.Property(x => x.Context).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Publish_Date).IsRequired();
            builder.ToTable("Comment");
        }
    }
}
