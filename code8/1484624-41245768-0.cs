    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BaseContext>()
               .As<IBaseContext>()
               .InstancePerLifetimeScope();
    
        builder.RegisterType<BaseDbManager<BaseContext>>().As<IBaseDbManager>()
               .WithParameter(new TypedParameter(typeof(BaseContext), new BaseContext()))
               .InstancePerLifetimeScope();
    }
