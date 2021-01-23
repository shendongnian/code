    public sealed class Logger
    {
        static readonly Logger instance;
        static Logger()
        {
            instance = new Logger();
        }
        public static Logger GetInstance()
        {
            return instance;
        }
        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        private Logger() {}
        public void Log(string whatToLog)
        {
           string s = whatToLog + " " + DateTime.Now.ToString();
           queue.Enqueue(s);
        }
    }
