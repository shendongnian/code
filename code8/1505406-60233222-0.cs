private static void ConfigureLogging(ILoggingBuilder log)
{
    log.ClearProviders();
    log.SetMinimumLevel(LogLevel.Error);
    log.AddConsole();
}
private static void ConfigureContainer(ContainerBuilder builder)
{
    builder.Register(handler => LoggerFactory.Create(ConfigureLogging))
        .As<ILoggerFactory>()
        .SingleInstance()
        .AutoActivate();
    builder.RegisterGeneric(typeof(Logger<>))
        .As(typeof(ILogger<>))
        .SingleInstance();
    // other registrations
}
And this on you main startup code: 
var containerBuilder = new ContainerBuilder();
ConfigureContainer(containerBuilder);
var container = containerBuilder.Build();
var serviceProvider = new AutofacServiceProvider(container);
// you can use either the built container or set the serviceProvider onto the library you are using.
