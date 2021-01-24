    public class MyLogger : ILogger
    {
        private string  categoryName;
        private ILogger baseLogger;
        
        public MyLogger(string categoryName, ILogger baseLogger)
        {
            this.categoryName = categoryName;
            this.baseLogger   = baseLogger;
        }
    
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.Information 
               && categoryName.StartsWith("Microsoft.AspNetCore"))
            {
                logLevel = LogLevel.Debug;
            }
            baseLogger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
