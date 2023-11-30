using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> Customers { get; set; } = new List<Customer> {
            new Customer
            {
                Id = 1,
                Name="Jane",
                Surname="Johnson"
            },
              new Customer
            {
                Id = 2,
                Name="Mike",
                Surname="Black"
            },
                new Customer
            {
                Id = 3,
                Name="Lisa",
                Surname="Kudrow"
            },
                  new Customer
            {
                Id = 4,
                Name="Monica",
                Surname="Geller"
            },  new Customer
            {
                Id = 5,
                Name="Daniel",
                Surname="Ronald"
            }
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var dataToreturn = Customers.Select(c =>
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
            var customer = Customers.FirstOrDefault(c => c.Id == id);
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
                Customers.Add(obj);
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
                var item = Customers.FirstOrDefault(c => c.Id == id);
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
            var item = Customers.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                Customers.Remove(item);
                return NoContent();
            }
            return NotFound();
        }
    }
}
