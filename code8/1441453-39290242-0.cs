    [Serializable]
    public class LogExecutionTimeAttribute : OnMethodBoundaryAspect
    {
        public static Func<ILog> GetLogger;
        // ...
    }
    public static class LoggerFactory
    {
        [ThreadStatic]
        public static ILog Logger;
        public static ILog GetLogger()
        {
            return Logger;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Configure factory only once.
            LogExecutionTimeAttribute.GetLogger = LoggerFactory.GetLogger;
            // ...
        }
        private static void HelloTask(int id)
        {
            var log  = new LogFileLogger(id.ToString()).LogInstance;
            LoggerFactory.Logger = log;
            // ...
         }
    }
