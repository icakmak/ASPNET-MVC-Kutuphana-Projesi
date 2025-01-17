﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kutuphane.Data.Repositories
{
    
    public interface IRepository<T> where T:class
    {

        //DB CRUD işlemleri için tanımladığımız sınıf
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void Delete(int id);


    }
}
