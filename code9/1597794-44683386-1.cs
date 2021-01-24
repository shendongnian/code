    public class Logger  :ILogger
    {
        private ILog log = null;
        public Logger(Type logClass)
        {
            log = LogManager.GetLogger(logClass);
        }
