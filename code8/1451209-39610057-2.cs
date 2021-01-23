    public sealed class MicrosoftLoggingAdapter  : ILogger
    {
        private readonly Microsoft.Extensions.ILogger adaptee;
        public MicrosoftLoggingAdapter (Microsoft.Extensions.ILogger adaptee) =>
            this.adaptee = adaptee;
        public void Log(LogEntry e) =>
			adaptee.Log(ToLevel(e.Severity), 0, e.Message, e.Exception, (s, _) => s);		
		private static LogLevel ToLevel(LoggingEventType s) =>
			s == LoggingEventType.Debug ? LogLevel.Debug  :
			s == LoggingEventType.Information ? LogLevel.Information :
			s == LoggingEventType.Warning ? LogLevel.Warning :
			s == LoggingEventType.Error ? LogLevel.Error :
			LogLevel.Critical;		
    }
