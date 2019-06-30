using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        void OpenSession();
        void BeginTransation();
        ISession Session { get; }
    }

}
