using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var dataToreturn = _productService.GetAll().Select(p =>
            {
                return new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount
                };
            });
            return dataToreturn;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                var dataToReturn = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                return dataToReturn;
            }
            return null;
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProductExtendDto product)
        {
            try
            {
                var obj = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount
                };
                _productService.Add(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductExtendDto product)
        {
            try
            {
                var item = _productService.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = product.Name;
                item.Price = product.Price;
                item.Discount = product.Discount;

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _productService.GetById(id);
            if (item != null)
            {
                _productService.Delete(id);
                return NoContent();
            }
            return NotFound();
        }
    }

}
