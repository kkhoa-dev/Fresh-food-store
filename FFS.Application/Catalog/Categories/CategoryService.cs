using FFS.Data.EF;
using FFS.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FFS.ViewModels.Common;
using FFS.ViewModels.Catalog.Products;
using FFS.Data.Entities;

namespace FFS.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly FFSDbContext _context;

        public CategoryService(FFSDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }
        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var user = await _context.Categories.FindAsync(id);
            if (user == null)
            {
                return new ApiErrorResult<bool>($"Danh mục {id} không tồn tại");
            }
            foreach (var category in request.Categories)
            {
                var CateInCategory = await _context.Categories
                    .FirstOrDefaultAsync(x => x.Id == int.Parse(category.Id)
                    );
                if (CateInCategory != null && category.Selected == false)
                {
                    _context.Categories.Remove(CateInCategory);
                }
                else if (CateInCategory == null && category.Selected)
                {
                    await _context.Categories.AddAsync(new Category()
                    {
                        Id = int.Parse(category.Id),
                      
                    }) ;
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}