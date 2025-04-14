using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MarketDbContext _context;

        public OrderRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public Order Get(Expression<Func<Order, bool>> expression)
        {
            return _context.Orders.SingleOrDefault(expression);
        }
        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o=>o.Id == id);    
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _context.Orders;
            return orders;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
