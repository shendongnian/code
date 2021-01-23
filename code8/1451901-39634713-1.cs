        private BlockingCollection<string> _producerQueue;
        void Consume()
        {
            foreach (var item in _producerQueue.GetConsumingEnumerable())
            {
               //do some work there
            }
        }
        void Produce()
        {
           _producerQueue.Add("a string to consume");
        }
        public void Start()
        {
            Task.Factory.StartNew(Consume);
        }
