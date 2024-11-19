using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos;
using ecommerce_api.Dtos.Product;
using ecommerce_api.Models;

namespace ecommerce_api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel){
            return new ProductDto{
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Slug = productModel.Slug,
                StockQuantity = productModel.StockQuantity,
                Status = productModel.Status,
                CategoryId = productModel.CategoryId,
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDto productDto){
            return new Product{
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Status = productDto.Status,
                CategoryId = productDto.CategoryId,
            };
        }
        public static Product ToProductFromUpdateDto(this UpdateProductDto productDto){
            return new Product{
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Status = productDto.Status,
                CategoryId = productDto.CategoryId,
            };
        }
    }
}