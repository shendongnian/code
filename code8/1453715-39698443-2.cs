    builder.RegisterType<ConcreteStuffFactory>()
           .As<IStuffFactory>();
    builder.RegisterType<HttpContextUserContextProvider>()
           .As<IUserContextProvider>()
           .InstancePerRequest();
    builder.Register(c => c.Resolve<IStuffFactory>().CreateStuffModel())
           .As<IStuffModel>()
           .InstancePerRequest();
