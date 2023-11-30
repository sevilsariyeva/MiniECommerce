using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> Products { get; set; } = new List<Product> {
            new Product
            {
                Id = 1,
                Name="T-Shirt",
                Price=59,
                Discount=15
            },
              new Product
            {
                Id = 2,
                Name="Trousers",
                Price=119,
                Discount=25
            },
                new Product
            {
                Id = 3,
                Name="Shirt",
                Price=89,
                Discount=5
            },
                  new Product
            {
                Id = 4,
                Name="Blouse",
                Price=69,
                Discount=35
            },  new Product
            {
                Id = 5,
                Name="Short",
                Price=79,
                Discount=45
            }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var dataToreturn = Products.Select(p =>
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
            var product = Products.FirstOrDefault(p => p.Id == id);
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
                Products.Add(obj);
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
                var item = Products.FirstOrDefault(p => p.Id == id);
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
            var item = Products.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                Products.Remove(item);
                return NoContent();
            }
            return NotFound();
        }
    }


}
