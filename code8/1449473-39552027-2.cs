    public sealed class Logger
    {
        public static Logger instance {get; private set;}
        static Logger()
        {
            instance = new Logger();
        }
        private ConcurrentQueue<Tuple<string, DateTime>> queue = new ConcurrentQueue<Tuple<string, DateTime>>();
        private Logger() {}
        public void Log(string whatToLog)
        {
           queue.Enqueue(new Tuple(whatToLog, DateTime.Now));
        }
    }
