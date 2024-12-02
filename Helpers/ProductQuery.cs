using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_api.Helpers
{
    public class ProductQuery
    {
         public string Name { get; set; } = string.Empty;

         public string? SortBy { get; set; } = null;
    }
}