    public static class DbContextExtensions
    {
        public static void LogToConsole(this DbContext context)
        {
            var contextServices = ((IInfrastructure<IServiceProvider>) context).Instance;
            var loggerFactory = contextServices.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddConsole(LogLevel.Verbose);
        }
    }
