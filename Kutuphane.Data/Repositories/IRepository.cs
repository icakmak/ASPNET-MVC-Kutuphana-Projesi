using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kutuphane.Data.Repositories
{
    
    public interface IRepository<T> where T:class
    {

        //DB CRUD işlemleri için tanımladığımız sınıf
        IQueryable GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);


    }
}
