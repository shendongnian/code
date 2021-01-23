    builder.RegisterType<LoggerFactory>()
        .As<ILoggerFactory>()
        .SingleInstance();
    builder.RegisterGeneric(typeof(Logger<>))
        .As(typeof(ILogger<>))
        .SingleInstance();
