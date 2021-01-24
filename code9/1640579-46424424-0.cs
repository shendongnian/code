    public static class AppLoggerExtensions
    {
        public static ILoggingBuilder AddAppLogger(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, AppLoggerProvider>();
            return builder;
        }
    }
