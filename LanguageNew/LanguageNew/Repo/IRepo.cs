using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageNew.Repo
{
    public interface IRepo<T> where T:class
    {
            T Get(string id);
            IEnumerable<T> GetAll();
            // IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
            bool Add(T entity);
            bool Delete(T entity);
            bool Update(T Entity);
        
    }
}
