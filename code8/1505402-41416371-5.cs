    builder.RegisterType<LoggerFactory>()
        .As<ILoggerFactory>()
        .SingleInstance();
    builder.RegisterType(typeof(Logger<>))
        .As(typeof(ILogger<>))
        .SingleInstance();
