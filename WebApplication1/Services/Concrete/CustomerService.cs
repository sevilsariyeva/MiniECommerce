using System.Linq.Expressions;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer entity)
        {
            _customerRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var item = _customerRepository.Get(x => x.Id == id);
            _customerRepository.Delete(item);
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            return _customerRepository.Get(expression);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerRepository.Update(entity);
        }
    }
}
