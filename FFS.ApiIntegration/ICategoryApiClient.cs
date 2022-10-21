using FFS.ViewModels.Catalog.Categories;
using FFS.ViewModels.Catalog.Products;
using FFS.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFS.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);
        Task<CategoryVm> GetById(string languageId, int id);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

    }
   
}
