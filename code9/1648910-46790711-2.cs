    var builder = new ContainerBuilder();
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    Builder.RegisterType<Repository>()
       .As<IRepository>()
       .InstancePerRequest();
