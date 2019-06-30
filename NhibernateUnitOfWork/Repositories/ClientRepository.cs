using NhibernateUnitOfWork.Infra;
using NhibernateUnitOfWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Repositories
{
    public class ClientRepository : Repository<Client, int>, IClientRepository
    {
        public ClientRepository(IUnitOfWork uow) : base(uow) { }
    }
}
