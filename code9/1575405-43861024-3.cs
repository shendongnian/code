    public class MyClass
    {
        private readonly object _lock = new object();
        private Task _task;
    
        public Task FooAsync()
        {
                lock (_lock)
                {
                    return _task != null ? _task : (_task = FooAsyncImpl());
                }
        }
        public async Task FooAsyncImpl()
        {
            try
            {
                // do async stuff
            }
            finally
            {
                lock (_lock) _task = null;
            }
        }
    }
