using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Infra
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private ITransaction _transaction;

        public ISession Session { get => _session; }

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task Commit()
        {
            try
            {
                await this._transaction.CommitAsync();
            }
            catch
            {
                await this._transaction.RollbackAsync();

                throw;
            }
        }

        public void OpenSession()
        {
            if (this._session == null || !this._session.IsConnected)
            {
                this._session = _sessionFactory.OpenSession();
            }
        }

        public void BeginTransation()
        {
            if (this._transaction == null || !this._transaction.IsActive)
            {

                this._transaction = this._session.BeginTransaction(IsolationLevel.ReadCommitted);
            }
        }


        public void Dispose()
        {
            if (this._transaction != null)
            {
                this._transaction.Dispose();
                this._transaction = null;
            }

            if (this._session != null)
            {
                this._session.Dispose();
                _session = null;
            }
        }
    }
}
