using AngularBlog.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBlog.Data.Model.Mapping
{
    class ApplicationCategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID);
            builder.ToTable("Category");
        }
    }
}
