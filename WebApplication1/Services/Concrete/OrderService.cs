using System.Linq.Expressions;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;
using WebApplication1.Repositories.Concrete;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var item = _orderRepository.Get(x => x.Id == id);
            _orderRepository.Delete(item);
        }

        public Order Get(Expression<Func<Order, bool>> expression)
        {
            return _orderRepository.Get(expression);
        }
        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
