    class NamedMutex : IDisposable
    {
        private readonly Thread _thread;
        private readonly ManualResetEventSlim _disposalGate;
        public NamedMutex()
        {
            var constructorGate = new ManualResetEventSlim();
            _disposalGate = new ManualResetEventSlim();
            _thread = new Thread(() =>
            {
                // Code here to acquire the mutex
                constructorGate.Set();
                _disposalGate.Wait();
                // Code here to release the mutex
            });
            _thread.Start();
            constructorGate.Wait();
        }
        
        public void Dispose()
        {
            _disposalGate.Set();
        }
    }
