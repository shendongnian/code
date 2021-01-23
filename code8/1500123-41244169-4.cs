    container.RegisterSingleton<ILoggerFactory>(factory);
    container.RegisterConditional(
        typeof(MyApplication.Abstractions.ILogger),
        c => typeof(MicrosoftLoggingAdapter<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Singleton,
        c => true);
