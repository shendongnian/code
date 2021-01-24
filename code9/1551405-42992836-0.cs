        private object _lock = new object();
        private int i = 0;
        private int max = 6;
        public IEnumerable<int> GetNumbers()
        {
            while (true)
            {
                lock (_lock)
                {
                    i++;
                    if (i == max)
                        i = 1;
                    yield return i;
                }
            }
        }
