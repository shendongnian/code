public class ErrorLogRepository
    {
        private static Logger _logger;
        public ErrorLogRepository()
        {
            if(_logger == null)
            {
                _logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(logs\\log.txt)
                    .CreateLogger();
            } 
        }
        public void Log()
        {
            Log.Information("I'm right now in the Class", DateTime.Now);
        }
    }
With this class, everytime you create an instance of it, the constructor will validate if a Logger has been created before. That way, you will always use the same Logger for different classe, and you will always write on the same file.
