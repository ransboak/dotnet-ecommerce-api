using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_api.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Slug { get; set; } = string.Empty;

        public int StockQuantity { get; set; }

        public string Status { get; set; } = string.Empty;

        public int? CategoryId { get; set; }
    }
}