        private Queue<string> MyQueue = new Queue<string>();
        private object _lock = new object();
        public void Worker()
        {
            do
            {
                string val = "";
                lock (_lock)
                {
                    if (MyQueue.Count > 0)
                    {
                        val = MyQueue.Dequeue();
                    }
                }
                if (val == "")
                {
                    System.Threading.Thread.Sleep(500);
                }
            } while (true);
        }
        public void Add(string rec)
        {
            lock (_lock)
            {
                MyQueue.Enqueue(rec);
            }
        }
