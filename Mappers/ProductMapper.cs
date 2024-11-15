using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos;
using ecommerce_api.Models;

namespace ecommerce_api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel){
            return new ProductDto{
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Slug = productModel.Slug,
                StockQuantity = productModel.StockQuantity,
                Status = productModel.Status,
                CategoryId = productModel.CategoryId,
            };
        }
    }
}