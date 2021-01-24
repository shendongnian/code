    public class RequestDurationLogger : ILogger, ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => this;
        public void Dispose() { }
        public IDisposable BeginScope<TState>(TState state) => NullDisposable.Instance;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (state.GetType().FullName == "Microsoft.AspNetCore.Hosting.Internal.HostingRequestFinishedLog" &&
                state is IReadOnlyList<KeyValuePair<string, object>> values &&
                values.FirstOrDefault(kv => kv.Key == "ElapsedMilliseconds").Value is double milliseconds)
            {
                Console.WriteLine($"Request took {milliseconds} ms");
            }
        }
        private class NullDisposable : IDisposable
        {
            public static readonly NullDisposable Instance = new NullDisposable();
            public void Dispose() { }
        }
    }
