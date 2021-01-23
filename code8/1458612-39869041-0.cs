    builder
        .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .As(type => type.GetInterfaces()
            .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
            .Select(t => new KeyedService("requestHandler", t)))
        .InstancePerLifetimeScope();
