using System.Linq.Expressions;

namespace WebApplication1.Services.Abstract
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> expression);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
