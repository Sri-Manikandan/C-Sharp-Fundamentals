using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase{
        private readonly IProductService _service;
        public ProductsController(IProductService service){
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = $"Product ID {id} not found." });
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById),
                new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
        {
            var product = await _service.UpdateAsync(id, dto);
            if (product == null)
                return NotFound(new { message = $"Product ID {id} not found." });

            return Ok(product);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Product ID {id} not found." });
            return Ok(new { message = $"Product ID {id} deleted." });
        }
    }
}
