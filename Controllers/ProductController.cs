using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_api.Dtos;
using ecommerce_api.Dtos.Product;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto){
            var productModel = productDto.ToProductFromCreateDto();

            var product = await _productRepo.CreateAsync(productModel);

            return CreatedAtAction(nameof(GetById), new { id = productModel.Id}, productModel.ToProductDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto productDto){
            var product = await _productRepo.UpdateAsync(id, productDto);

            if(product == null){
                return NotFound();
            }

            return Ok(product.ToProductDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var product = await _productRepo.DeleteAsync(id);

            if(product == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}