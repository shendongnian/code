        public static class ContainerConfig
    {
    
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
    
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<DataRepository>().As<IDataRepository>();
            builder.RegisterType<DataService>().As<IDataService>();
    
            return builder.Build();
        }
    }
