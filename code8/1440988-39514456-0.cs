    public class LoggerFactory
    {
        private static ILoggerFactoryStrategy _loggerFactoryStrategy = new DummyLoggerFactoryStrategy();
        public static void Initialize(ILoggerFactoryStrategy loggerFactoryStrategy)
        {
            _loggerFactoryStrategy = loggerFactoryStrategy;
        }
        public ILogger GetLogger<T>()
        {
            return _loggerFactoryStrategy.GetLoggerWithName(typeof(T).Name);
        }
        ....
    }
