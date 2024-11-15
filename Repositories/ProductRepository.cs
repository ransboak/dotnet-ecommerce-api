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
        public Task<Product> CreateAsync(Product productModel)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(int id, UpdateProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}