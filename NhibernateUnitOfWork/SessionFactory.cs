using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NhibernateUnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibernateUnitOfWork
{
    public class SessionFactory
    {
        public static ISessionFactory Init(string configurationString)
        {
            object __sync = new object();

            lock (__sync)
                return Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.
                ConnectionString(configurationString))
                 .Mappings(m => m.FluentMappings.Add<ClientMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                               .Create(false, false))
                .BuildSessionFactory();
        }

    }
}
