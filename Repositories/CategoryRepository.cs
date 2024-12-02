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

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            string baseSlug = categoryModel.Name.ToLower().Replace(" ", "-");
            categoryModel.Slug = await GenerateUniqueSlugAsync(baseSlug);
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public Task<Category?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(x => x.Id == id);

            if(category == null){
                return null;
            }
            return category;
        }

        public Task<Category?> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateUniqueSlugAsync(string baseSlug)
        {
            string uniqueSlug = baseSlug;
            int count = 1;

            // Check for uniqueness in the database
            while (await _context.Products.AnyAsync(p => p.Slug == uniqueSlug))
            {
                uniqueSlug = $"{baseSlug}-{count}";
                count++;
            }

            return uniqueSlug;
        }
    }
}