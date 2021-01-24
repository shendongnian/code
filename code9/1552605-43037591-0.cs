	// First option, with a parameter
	builder
        .RegisterType<Context>()
        .AsSelf()
        .WithParameter(
            (parameter, context) => parameter.Name == CONNECTION_STRING,
            (parameter, context) => context.Resolve<IUserDatabase>().ConnectionString));
    // Second option, with a lambda
    builder
    	.Register(x => new Context(x.Resolve<IUserDatabase>().ConnectionString))
    	.AsSelf();
