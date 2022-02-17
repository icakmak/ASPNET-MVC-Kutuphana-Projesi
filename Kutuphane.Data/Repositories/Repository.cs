using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /*
         DB işlemleri CREATE,READ,UPDATE ve DELETE işlemleri için kullanılacak olan bu sınıfı
         SQL sorgularını azaltmak için kullanıyoruz otomatik olarak bu sınıfdan metod çağırıp 
        lsiteleme ekleme silme gibi işlemleri yaptırıyoruz
         */
        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) { return; }
            Delete(entity);

        }
    }
}
