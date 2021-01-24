    builder.RegisterType<DataService>()
           .Keyed<IDataService>(FiberModule.Key_DoNotSerialize)
           .AsImplementedInterfaces()
           .SingleInstance();
    builder.RegisterBuildCallback(c => c.Resolve<IDataSerialize>().Initialise());
