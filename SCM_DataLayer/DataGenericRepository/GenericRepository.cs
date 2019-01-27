using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using SCM_DataLayer.DataContext;

namespace SCM_DataLayer.DataGenericRepository
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private DataDbContext context;

        public GenericRepository()
        {

            context = new DataDbContext();
        }
        
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Func<T, bool> predicate)
        {
            context.Set<T>().Where(predicate).ToList().ForEach(del => context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            if(context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public T Find(params object[] key)
        {
            return context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T entity)
        {
             context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
