    public static Global
    {
        private static int _counter = 0;
        private static readonly object _lockObject = new object();
        public static void Increment()
        {
            lock (_lockObject) {
                _counter++;
            }
        }
        public static int Counter
        {
            get
            {
                lock (lockObject) {
                    return _counter;
                }
            }
        }
    }
