using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.ViewModels.Catalog.Categories
{
    public class GetCategoryRequest
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }
        public int? Id { set; get; }
    }
}
