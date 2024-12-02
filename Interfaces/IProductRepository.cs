using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos.Product;
using ecommerce_api.Helpers;
using ecommerce_api.Models;

namespace ecommerce_api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQuery query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productDto);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> DeleteAsync(int id);
    }
}