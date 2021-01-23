    builder.RegisterType<ConcreteStuffFactory>()
           .As<IStuffFactory>();
    builder.Register(c => c.Resolve<IStuffFactory>()
                           .CreateStuffModel(Helper.GetParsedUserName()))
           .As<IStuffModel>()
           .InstancePerRequest();
