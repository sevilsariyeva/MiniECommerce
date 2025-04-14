using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var dataToreturn = _orderService.GetAll().Select(o =>
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
            var order = _orderService.GetAll().FirstOrDefault(o => o.Id == id);
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
                _orderService.Add(obj);
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
                var item = _orderService.GetById(id);
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
            var item = _orderService.GetById(id);
            if (item != null)
            {
                _orderService.Delete(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
