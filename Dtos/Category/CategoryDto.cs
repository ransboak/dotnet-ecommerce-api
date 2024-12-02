using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Models;

namespace ecommerce_api.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public List<ProductDto> Products { get; set; }
    }
}