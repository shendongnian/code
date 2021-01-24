    public class UsesConcurrentQueue
    {
        private readonly ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        public void Write(string data)
        {
            _queue.Enqueue(data);
        }
        private void TimerElapsed(object obj)
        {
            string dataToProcess = null;
            while(_queue.TryDequeue(out dataToProcess))
            {
                // process each string;
            }
        }
    }
