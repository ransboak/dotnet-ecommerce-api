using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos.Category;
using ecommerce_api.Models;

namespace ecommerce_api.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel){
            return new CategoryDto{
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                Slug = categoryModel.Slug,
                Products = categoryModel.Products.Select(s => s.ToProductDto()).ToList()
            };
        }
        public static Category ToCategoryFromCreateDto(this CreateCategoryDto categoryDto){
            return new Category{
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
        }
        public static Category ToCategoryFromUpdateDto(this UpdateCategoryDto categoryDto){
            return new Category{
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
        }
    }
}