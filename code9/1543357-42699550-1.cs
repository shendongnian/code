    class NamedMutex : IDisposable
    {
        private readonly Thread _thread;
        private readonly ManualResetEventSlim _disposalGate;
        private readonly Mutex _namedMutex;
        public NamedMutex(string name)
        {
            var constructorGate = new ManualResetEventSlim();
            _disposalGate = new ManualResetEventSlim();
            _thread = new Thread(() =>
            {
                // Code here to acquire the mutex
                _namedMutex = new Mutex(initiallyOwned: false, name: name, createdNew: out _createdNew);
                constructorGate.Set(); // Tell the constructor it can go on
                _disposalGate.Wait(); // Wait for .Dispose to be called
                // Code here to release the mutex
                _namedMutex.ReleaseMutex();
                _namedMutex.Dispose();
            });
            _thread.Start();
            constructorGate.Wait();
        }
        
        public void Dispose()
        {
            _disposalGate.Set();
        }
    }
