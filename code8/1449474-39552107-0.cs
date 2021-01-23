    public static class Logger
    {
        private static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        public static void Log(string LogMessage)
        {
            // thread safe logging
            queue.Enqueue($"{LogMessage} {DateTime.Now}");
        }
        //dequeue only within namespace
        internal static string Dequeue() {
            string dequeuedItem;
            queue.TryDequeue(out dequeuedItem);
            return dequeuedItem;
        }
    }
    public class LoggerReader
    {
        public LoggerReader()
        {
            // create other objects here AND a thread that extracts
            // from the queue and writes to a file
            // because queue is thread safe this is perfectly ok
            string logItem = Logger.Dequeue();
        }
    }
