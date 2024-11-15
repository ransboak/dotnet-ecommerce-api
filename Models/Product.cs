using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_api.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Slug { get; set; } = string.Empty;

        [Required]
        public int StockQuantity { get; set; }

        public string Status { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}