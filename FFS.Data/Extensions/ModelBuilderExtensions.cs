using FFS.Data.Entities;
using FFS.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of Fresh Food Store" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of Fresh Food Store" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of Fresh Food Store" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Các loại hạt", LanguageId = "vi", SeoAlias = "cac-loai-hat", SeoDescription = "Sản phẩm làm từ hạt", SeoTitle = "Sản phẩm làm từ hạt" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Nuts", LanguageId = "en", SeoAlias = "nuts-nuts", SeoDescription = "Products made from seeds", SeoTitle = "Products made from seeds" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Rau, củ quả", LanguageId = "vi", SeoAlias = "rau-cu-qua", SeoDescription = "Sản phẩm làm từ rau,củ,quả", SeoTitle = "Sản phẩm làm từ rau,củ,quả" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Vegetable", LanguageId = "en", SeoAlias = "vega-vegatables", SeoDescription = "Products made from vegetables", SeoTitle = "Products made from vegetables" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Hạt Dưa 300g",
                     LanguageId = "vi",
                     SeoAlias = "hat-dua-300g",
                     SeoDescription = "Hạt dưa được làm từ 100% là hạt dưa thơm ngon, béo ngậy và không chứa phẩm màu độc hại",
                     SeoTitle = "Hạt dưa được làm từ 100% là hạt dưa thơm ngon, béo ngậy và không chứa phẩm màu độc hại",
                     Details = "Hạt dưa được làm từ 100% là hạt dưa thơm ngon, béo ngậy và không chứa phẩm màu độc hại",
                     Description = "Hạt dưa được làm từ 100% là hạt dưa thơm ngon, béo ngậy và không chứa phẩm màu độc hại"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Melon Seeds 300g",
                        LanguageId = "en",
                        SeoAlias = "Melon-Seeds-300g",
                        SeoDescription = "Melon seeds are made from 100% delicious, greasy melon seeds and do not contain harmful dyes",
                        SeoTitle = "Melon seeds are made from 100% delicious, greasy melon seeds and do not contain harmful dyes",
                        Details = "Melon seeds are made from 100% delicious, greasy melon seeds and do not contain harmful dyes",
                        Description = "Melon seeds are made from 100% delicious, greasy melon seeds and do not contain harmful dyes"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // Tool>new guid
            var roleId = new Guid("C28F66AE-186E-4C5F-9DF3-86B07F431013");
            var adminId = new Guid("C0D575DD-EE8B-4905-8FCA-59F5AC4A05CD");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator Role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "truongquochung204@gmail.com",
                NormalizedEmail = "truongquochung204@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Quoc",
                LastName = "Hung",
                Dob = new DateTime(2021, 12, 06)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "images/hinh-anh-trang-chu/banner/banner-1.png", Status = Status.Active },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "images/hinh-anh-trang-chu/banner/banner-2.png", Status = Status.Active },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "images/hinh-anh-trang-chu/banner/banner-3.jpg", Status = Status.Active }
              );
        }




    }
}
