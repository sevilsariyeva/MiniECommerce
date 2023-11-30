using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MarketDbContext _context;

        public CustomerRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            var customer = _context.Customers.SingleOrDefault(expression);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers;
            return customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
