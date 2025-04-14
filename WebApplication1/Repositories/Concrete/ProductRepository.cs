using System.Linq;
using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketDbContext _context;

        public ProductRepository(MarketDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            var product = _context.Products.SingleOrDefault(expression);
            return product;
        }
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetAll()
        {
            var product = _context.Products;
            return product;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
