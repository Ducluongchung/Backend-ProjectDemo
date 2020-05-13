using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDocker.Domain.Dtos;
using DemoDocker.Service.ProductSevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagingProduct([FromQuery] ProductPagingRequest request)
        {
            var product = await _product.GetAllPaging(request);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            var product = await _product.Delete(productId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _product.Create(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _product.Update(request);
            return Ok();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetDetailProduct(int productId)
        {
            var product = await _product.ProductDetail(productId);
            return Ok(product);
        }
    }
}