using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Data.Repository
{
    public interface IRepository<T>: IDisposable where T:class
    {
        List<T> List();
        List<T> Search(Expression<Func<T, bool>> predicate);
        T Save(T obj);
        T Update(T obj);
        void Delete(int id);
        T Get(int id);
        bool Any(Expression<Func <T, bool>> predicate);
    }
}
