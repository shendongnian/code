    public Class LogSingleTon
    {
  
        private static readonly Lazy<LogSingleTon> lazy =
            new Lazy<LogSingleTon>(() => new LogSingleTon());
 
        public static LogSingleTon Instance { get { return lazy.Value; } }
        private ILog log ;
        private LogSingleTon()
        {
            log = LogManager.GetLogger("CommonLogger")
        }
        public void LogMessage(string message)
        {
            Task.Factory.StartNew(() => log.Info(message));
        }      
}
