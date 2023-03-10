using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BookStore.Data.Repositories.Interfaces;
using Assignment2.DataAccess;

namespace BookStore.Data.Repositories.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly eBookStoreContext _context;
        public BaseRepository(eBookStoreContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
           _dbSet.Remove(entity);
            return true;
        }

        public T? Get(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}
