using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Data;
using ecommerce_api.Dtos.Category;
using ecommerce_api.Interfaces;
using ecommerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Category> CreateAsync(Category categoryModel)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}