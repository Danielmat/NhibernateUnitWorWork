using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Model
{
    public interface IClientRepository : IRepository<Client, int> { }
}
