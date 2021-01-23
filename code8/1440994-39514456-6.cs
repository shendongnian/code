    internal class NLogLogger : ILogger
    {
        private readonly Logger _logger;
        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }
        public void Debug(string message)
        {
            _logger.Debug(message);
        }
        public void Warn(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }
        public void Info(Exception exception)
        {
            _logger.Info(exception);
        }
 
        ......
    }
