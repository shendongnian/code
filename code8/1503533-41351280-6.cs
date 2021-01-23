    public class LogService
    {
        private readonly LogContext _logContext;
        public LogService(LogContext logContext)
        {
           _logContext = logContext;
        }
    
        List<Log> GetLogType(string type)
        {
            return _logContext.Logs.Where(x => x.Type == type).ToList();    
        }
    }
