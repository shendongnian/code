        private List<string> list = new List<string>();
        private readonly object locker = new object();
        public void Write(string data)
        {
            lock (locker)
            {
                list.Add(data);
            }
        }
        // guaranteed non-reentrant code
        private void TimerElapsed(object obj)
        {
            List<string> copy;
            lock (locker)
            {
                copy = list;
                list = new List<string>();
            }
            
            // process copy
        }
