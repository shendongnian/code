    class NamedSlimLocker
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _semaphoreSlimDict;
        static NamedSlimLocker()
        {
            _semaphoreSlimDict = new ConcurrentDictionary<string, SemaphoreSlim>();
        }
        private readonly string _name;
        private readonly SemaphoreSlim _semaphore;
        public NamedSlimLocker(string name)
        {
            this._name = name;
            _semaphore = _semaphoreSlimDict.GetOrAdd(name, (n) => new SemaphoreSlim(1,1));
        }
        public async Task RunLockedAsync(Func<Task> action)
        {
            try
            {
                await _semaphore.WaitAsync();
                await action();
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<T> RunLockedAsync<T>(Func<Task<T>> action)
        {
            try
            {
                await _semaphore.WaitAsync();
                return await action();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
