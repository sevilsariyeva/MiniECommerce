using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public static List<Order> Orders { get; set; } = new List<Order> {
            new Order
            {
                Id = 1,
                 ProductId = 1,
                 CustomerId = 1,
                 OrderDate = DateTime.Now
            },
              new Order
            {
                Id = 2,
                ProductId=2,
                CustomerId = 2,
                OrderDate = DateTime.Now
            },
                new Order
            {
                Id = 3,
                ProductId=3,
                CustomerId=3,
                OrderDate = DateTime.Now
            },
                  new Order
            {
                Id = 4,
                ProductId=4,
                CustomerId=4,
                OrderDate = DateTime.Now
            },  new Order
            {
                Id = 5,
                ProductId=5,
                CustomerId=5,
                OrderDate = DateTime.Now
            }
        };

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var dataToreturn = Orders.Select(o =>
            {
                return new Order
                {
                    Id = o.Id,
                    ProductId=o.Id,
                    CustomerId=o.Id,
                };
            });
            return dataToreturn;
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                var dataToReturn = new Order
                {
                    Id = order.Id,
                    ProductId = order.Id,
                    CustomerId = order.Id
                };
                return dataToReturn;
            }
            return null;
        }
        [HttpPost]
        public IActionResult Post([FromBody] OrderExtendDto order)
        {
            try
            {
                var obj = new Order
                {
                    Id = order.Id,
                    ProductId = order.Id,
                    CustomerId = order.Id
                };
                Orders.Add(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderExtendDto order)
        {
            try
            {
                var item = Orders.FirstOrDefault(o => o.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                item.ProductId = order.ProductId;
                item.CustomerId = order.CustomerId;
                item.OrderDate = order.OrderDate;

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
            var item = Orders.FirstOrDefault(o => o.Id == id);
            if (item != null)
            {
                Orders.Remove(item);
                return NoContent();
            }
            return NotFound();
        }
    }
}
