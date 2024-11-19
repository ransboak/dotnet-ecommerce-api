using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Data;
using ecommerce_api.Dtos.Product;
using ecommerce_api.Interfaces;
using ecommerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product productModel)
        {
            string baseSlug = productModel.Name.ToLower().Replace(" ", "-");
            productModel.Slug = await GenerateUniqueSlugAsync(baseSlug);
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Description = productDto.Description;
            existingProduct.StockQuantity = productDto.StockQuantity;
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.Status = productDto.Status;
            
            if (existingProduct.Name != productDto.Name)
            {
                string baseSlug = productDto.Name.ToLower().Replace(" ", "-");
                existingProduct.Slug = await GenerateUniqueSlugAsync(baseSlug);
            }

            await _context.SaveChangesAsync();
            return existingProduct;
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