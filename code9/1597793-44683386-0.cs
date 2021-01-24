    public class Logger  :ILogger
    {
        private static ILog log = null;
        static Logger()
        {
            log = LogManager.GetLogger(typeof(Logger));
            GlobalContext.Properties["host"] = Environment.MachineName;
        }
        public Logger(Type logClass)
        {
            log = LogManager.GetLogger(logClass);
        }
