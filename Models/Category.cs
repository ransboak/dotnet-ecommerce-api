using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_api.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}