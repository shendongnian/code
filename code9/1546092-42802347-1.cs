    class CDataProducer
    {
        public bool IsDone { get; private set; }
        private double _data;
        private readonly Queue<double> _values = new Queue<double>();
        private readonly object _lock = new object();
        public void Done()
        {
            IsDone = true;
        }
        public void ProduceNewData()
        {
            lock (_lock)
            {
                _values.Enqueue(++_data);
                Monitor.Pulse(_lock);
            }
        }
        public bool WaitData(out double value)
        {
            lock (_lock)
            {
                while (_values.Count == 0)
                {
                    Monitor.Wait(_lock);
                }
                value = _values.Dequeue();
                return true;
            }
        }
    }
