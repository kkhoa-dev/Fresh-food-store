using FFS.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.ViewModels.Catalog.Categories
{
    public class CategoryVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
