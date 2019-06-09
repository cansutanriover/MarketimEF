using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MarketimEntities _db;

        public Repository(MarketimEntities db)
        {
            _db = db;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Any(predicate);
        }

        public void Delete(int id)
        {
            var result = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return _db.Set<T>().ToList();
        }

        public T Save(T obj)
        {
            _db.Set<T>().Add(obj);
            return obj;
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public T Update(T obj)
        {
            _db.Entry<T>(obj).State = System.Data.Entity.EntityState.Modified;
            return obj;
        }
    }
}
