    public class XUnitLoggerProvider : ILoggerProvider
    {
        public IWriter Writer { get; private set; }
        public XUnitLoggerProvider(IWriter writer)
        {
            Writer = writer;
        }
        public void Dispose()
        {
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new XUnitLogger(Writer);
        }
        public class XUnitLogger : ILogger
        {
            public IWriter Writer { get; }
            public XUnitLogger(IWriter writer)
            {
                Writer = writer;
                Name = nameof(XUnitLogger);
            }
            public string Name { get; set; }
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                if (!this.IsEnabled(logLevel))
                    return;
                if (formatter == null)
                    throw new ArgumentNullException(nameof(formatter));
                string message = formatter(state, exception);
                if (string.IsNullOrEmpty(message) && exception == null)
                    return;
                string line = $"{logLevel}: {this.Name}: {message}";
                Writer.WriteLine(line);
                if (exception != null)
                    Writer.WriteLine(exception.ToString());
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
            public IDisposable BeginScope<TState>(TState state)
            {
                return new XUnitScope();
            }
        }
        public class XUnitScope : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
