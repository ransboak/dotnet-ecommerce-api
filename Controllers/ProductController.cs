using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Interfaces;
using ecommerce_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var stocks = await _productRepo.GetAllAsync();

            var stockDto = stocks.Select(s => s.ToProductDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var product = await _productRepo.GetByIdAsync(id);

            if(product == null){
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }
    }
}