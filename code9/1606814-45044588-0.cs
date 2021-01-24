    public class SingleThreadSynchronizationContext : SynchronizationContext
    {
        private readonly BlockingCollection<(SendOrPostCallback callback, object state)> _queue;
        private readonly Thread _processingThread;
    
        public SingleThreadSynchronizationContext()
        {
            _queue = new BlockingCollection<(SendOrPostCallback, object)>();
            _processingThread = new Thread(Process) { IsBackground = true };
            _processingThread.Start();
        }
    
        public override void Send(SendOrPostCallback d, object state)
        {
            using (var mutex = new ManualResetEventSlim())
            {
                var callback = new SendOrPostCallback(s =>
                {
                    d(s);
                    mutex.Set();
                });
    
                _queue.Add((callback, state));
                mutex.Wait();
            }
        }
    
        public override void Post(SendOrPostCallback d, object state)
        {
            _queue.Add((d, state));
        }
    
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    
        private void Process()
        {
            SetSynchronizationContext(this);
    
            foreach (var item in _queue.GetConsumingEnumerable())
            {
                item.callback(item.state);
            }
        }
    }
