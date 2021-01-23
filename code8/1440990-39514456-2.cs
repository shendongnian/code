    public class LoggerFactoryStrategy : ILoggerFactoryStrategy
    {
        public ILogger GetLogger<T>()
        {
            //create LibLog instance instead with LogProvider.For<T>()
            var nlogger = LogManager.GetLogger(typeof(T).Name); //create instance of NLogger
            return new NLogLogger(nlogger);
        }
    }
