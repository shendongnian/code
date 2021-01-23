    public class HubLogger : AbstractSimpleLogger
    {
        private ILogger _logger;
        public HubLogger(ILogger logger, string logName, LogLevel logLevel, bool showLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
            : base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
        {
            _logger = logger;
        }
        
        protected override void WriteInternal(LogLevel level, object message, Exception e)
        {
            switch (level)
            {
                case LogLevel.All:
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Info:
                case LogLevel.Warn:
                case LogLevel.Error:
                    // Use a StringBuilder for better performance
                    StringBuilder sb = new StringBuilder();
                    FormatOutput(sb, level, message, e);
                    if (e != null)
                    {
                        _logger.Log(e);
                    }
                    _logger.Log(sb.ToString());
                    break;
                case LogLevel.Off:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("level", level, "invalid logging level");
            }
        }
