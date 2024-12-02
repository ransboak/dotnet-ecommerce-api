using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos.Category;
using ecommerce_api.Models;

namespace ecommerce_api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<Category?> UpdateAsync(int id, UpdateCategoryDto categoryDto);

        Task<Category> CreateAsync(Category categoryModel);

        Task<Category?> DeleteAsync(int id);

        
    }
}