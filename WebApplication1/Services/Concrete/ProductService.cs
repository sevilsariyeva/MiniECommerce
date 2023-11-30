using System.Linq.Expressions;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;
using WebApplication1.Repositories.Concrete;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var item = _productRepository.Get(x => x.Id == id);
            _productRepository.Delete(item);
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Get(expression);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
