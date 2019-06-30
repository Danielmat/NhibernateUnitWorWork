using FluentNHibernate.Mapping;
using NhibernateUnitOfWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork.Repositories
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Map(x => x.Name);
           
            Table("clients");
        }
    }
}
