using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Model
{
    public interface IRepository<T, TId>
    {
        Task Save(T entity);
        Task Remove(T entity);
        Task<T> FindBy(TId id);
    }

}
