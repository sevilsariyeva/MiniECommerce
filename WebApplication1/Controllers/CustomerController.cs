using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var dataToreturn = _customerService.GetAll().Select(c =>
            {
                return new Customer
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname=c.Surname 
                };
            });
            return dataToreturn;
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                var dataToReturn = new Customer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname= customer.Surname
                };
                return dataToReturn;
            }
            return null;
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerExtendDto customer)
        {
            try
            {
                var obj = new Customer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname= customer.Surname
                };
                _customerService.Add(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerExtendDto customer)
        {
            try
            {
                var item = _customerService.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = customer.Name;
                item.Surname = customer.Surname;

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
            var item = _customerService.GetById(id);
            if (item != null)
            {
                _customerService.Delete(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
