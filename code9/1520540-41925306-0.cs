    public class CollectionAppender : AppenderSkeleton
    {
        public static ObservableCollection<LogItem> logData = new ObservableCollection<LogItem>();
        protected override void Append(LoggingEvent loggingEvent)
        {
            logData.Add(new LogItem(loggingEvent));
        }
    }
    public class LogItem
    {
        public string Logger { get; private set; }
        public string Level { get; private set; }
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; }
        public Exception ExceptionData { get; private set; }
        public bool ShouldSerializeExceptionData() //This keeps things tidy when using Json.net for non exemption entries.
        {
            return ExceptionData != null;
        }
        public LogItem(LoggingEvent data)
        {
            Logger = data.LoggerName;
            Level = data.Level.DisplayName;
            Message = data.RenderedMessage;
            Timestamp = data.TimeStamp;
            ExceptionData = data.ExceptionObject;
        }
    }
