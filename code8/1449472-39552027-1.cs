    public sealed class Logger
    {
        public static Logger instance {get; private set;}
        static Logger()
        {
            instance = new Logger();
        }
        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        private Logger() {}
        public void Log(string whatToLog)
        {
           string s = whatToLog + " " + DateTime.Now.ToString();
           queue.Enqueue(s);
        }
    }
