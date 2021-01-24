    public class FakeLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Events.Add(eventId.Id);
        }
        public List<int> Events { get; set; } = new List<int>();
        public bool IsEnabled(LogLevel logLevel) => true;
        public IDisposable BeginScope<TState>(TState state) => null;
    }    
    
