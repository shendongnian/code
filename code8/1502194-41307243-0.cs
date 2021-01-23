    class QueueSynchronizationContext : SynchronizationContext {
        private readonly BlockingCollection<Tuple<SendOrPostCallback, object>> _queue = new BlockingCollection<Tuple<SendOrPostCallback, object>>(new ConcurrentQueue<Tuple<SendOrPostCallback, object>>());
        public QueueSynchronizationContext() {
            new Thread(() =>
            {
                foreach (var item in _queue.GetConsumingEnumerable()) {
                    item.Item1(item.Item2);
                }
            }).Start();
        }        
        public override void Post(SendOrPostCallback d, object state) {
            _queue.Add(new Tuple<SendOrPostCallback, object>(d, state));
        }
        public override void Send(SendOrPostCallback d, object state) {
            _queue.Add(new Tuple<SendOrPostCallback, object>(d, state));
        }
    }
