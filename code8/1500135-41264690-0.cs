        private void RegisterServices()
        {
            Container.Register(ConfigureLogger, Lifestyle.Singleton);            
            Container.Register(typeof(ILogger<>), typeof(LoggingAdapter<>));
        }
 
        private ILoggerFactory ConfigureLogger()
        {
            LoggerFactory factory = new LoggerFactory();
            var config = new ConfigurationBuilder()
                .AddJsonFile("logging.json")
                .Build();
            //serilog provider configuration
            var log = new LoggerConfiguration()
                     //.ReadFrom.Configuration(config)
                     .WriteTo
                     .RollingFile(ConfigSettings.LogsPath)
                     .CreateLogger();
            factory.AddSerilog(log);
            return factory;
        }
        
        public class LoggingAdapter<T> : ILogger<T>
        {
            private readonly Microsoft.Extensions.Logging.ILogger adaptee;          
            public LoggingAdapter(ILoggerFactory factory)
            {
                adaptee = factory.CreateLogger<T>();
            }
            public IDisposable BeginScope<TState>(TState state)
            {
                return adaptee.BeginScope(state);
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return adaptee.IsEnabled(logLevel);
            }
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                adaptee.Log(logLevel, eventId, state, exception, formatter);
            }
        }   
