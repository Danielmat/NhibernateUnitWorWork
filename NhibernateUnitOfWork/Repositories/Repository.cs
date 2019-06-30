using NhibernateUnitOfWork.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Repositories
{
    public abstract class Repository<T, TEntityKey>
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;

            _uow.OpenSession();

            _uow.BeginTransation();
        }
        public async Task Remove(T entity) => await _uow.Session.DeleteAsync(entity);
        public async Task Save(T entity) => await _uow.Session.SaveOrUpdateAsync(entity);
        public async Task<T> FindBy(TEntityKey id) => await _uow.Session.GetAsync<T>(id);

    }

}
