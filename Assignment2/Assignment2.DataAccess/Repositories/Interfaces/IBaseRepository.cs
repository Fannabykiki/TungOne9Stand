using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace BookStore.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        Boolean Delete(T entity);
        int SaveChanges();
    }
}
