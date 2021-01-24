        public class NamedAsyncReaderWriterLockController<TKey>
    {
        private readonly object _mutex = new object();
        private readonly Dictionary<TKey, NamedAsyncReaderWriterLock> _lockDict = new Dictionary<TKey, NamedAsyncReaderWriterLock>();
        
        public Task<IDisposable> EnterReaderLockAsync(TKey name)
        {
            lock (_mutex)
            {
                var locker = GetLock(name);
                return locker.EnterReaderLockAsync();
            }
        }
        public Task<IDisposable> EnterWriterLockAsync(TKey name)
        {
            lock (_mutex)
            {
                var locker = GetLock(name);
                return locker.EnterWriterLockAsync();
            }
        }
        private NamedAsyncReaderWriterLock GetLock(TKey name)
        {
            NamedAsyncReaderWriterLock locker;
            if (!_lockDict.TryGetValue(name, out locker))
            {
                locker = new NamedAsyncReaderWriterLock(this, name, _mutex);
                _lockDict.Add(name, locker);
            }
            return locker;
        }
        private void RemoveLock(TKey name)
        {
            _lockDict.Remove(name);
        }
        private class NamedAsyncReaderWriterLock
        {
            private readonly TKey _name;
            private readonly NamedAsyncReaderWriterLockController<TKey> _namedAsyncReaderWriterLockController;
            private readonly Queue<TaskCompletionSource<IDisposable>> _writerQueue = new Queue<TaskCompletionSource<IDisposable>>();
            private readonly Queue<TaskCompletionSource<IDisposable>> _readerQueue = new Queue<TaskCompletionSource<IDisposable>>();
            private readonly NamedWriterLock _namedWriterLock;
            private readonly NamedReaderLock _namedReaderLock;
            private readonly object _mutex = new object();
            private readonly object _releaseMutex;
            private int _locksHeld;
            public NamedAsyncReaderWriterLock(NamedAsyncReaderWriterLockController<TKey> namedAsyncReaderWriterLockController, TKey name, object releaseMutex)
            {
                _namedWriterLock = new NamedWriterLock(this);
                _namedReaderLock = new NamedReaderLock(this);
                _releaseMutex = releaseMutex;
                _name = name;
                _namedAsyncReaderWriterLockController = namedAsyncReaderWriterLockController;
            }
            public Task<IDisposable> EnterReaderLockAsync()
            {
                lock (_mutex)
                {
                    if (_locksHeld >= 0 && _writerQueue.Count == 0)
                    {
                        _locksHeld++;
                        return Task.FromResult<IDisposable>(_namedReaderLock);
                    }
                    var tcs = new TaskCompletionSource<IDisposable>();
                    _readerQueue.Enqueue(tcs);
                    return tcs.Task;
                }
            }
            public Task<IDisposable> EnterWriterLockAsync()
            {
                lock (_mutex)
                {
                    if (_locksHeld == 0)
                    {
                        _locksHeld = -1;
                        return Task.FromResult<IDisposable>(_namedWriterLock);
                    }
                    var tcs = new TaskCompletionSource<IDisposable>();
                    _writerQueue.Enqueue(tcs);
                    return tcs.Task;
                }
            }
            private void ReleaseLocks()
            {
                if (_locksHeld != 0)
                    return;
                // Give priority to writers.
                if (_writerQueue.Count != 0)
                {
                    _locksHeld = -1;
                    var tcs = _writerQueue.Dequeue();
                    tcs.TrySetResult(_namedWriterLock);
                    return;
                }
                // Then to readers.
                while (_readerQueue.Count != 0)
                {
                    var tcs = _readerQueue.Dequeue();
                    tcs.TrySetResult(_namedReaderLock);
                    ++_locksHeld;
                }
                if (_locksHeld == 0) _namedAsyncReaderWriterLockController.RemoveLock(_name);
            }
            private void ReleaseReaderLock()
            {
                lock (_releaseMutex)
                {
                    lock (_mutex)
                    {
                        _locksHeld--;
                        ReleaseLocks();
                    }
                }
            }
            private void ReleaseWriterLock()
            {
                lock (_releaseMutex)
                {
                    lock (_mutex)
                    {
                        _locksHeld = 0;
                        ReleaseLocks();
                    }
                }
            }
            private class NamedReaderLock : IDisposable
            {
                private readonly NamedAsyncReaderWriterLock _namedAsyncReaderWriterLock;
                internal NamedReaderLock(NamedAsyncReaderWriterLock namedAsyncReaderWriterLock)
                {
                    _namedAsyncReaderWriterLock = namedAsyncReaderWriterLock;
                }
                public void Dispose()
                {
                    _namedAsyncReaderWriterLock.ReleaseReaderLock();
                }
            }
            private class NamedWriterLock : IDisposable
            {
                private readonly NamedAsyncReaderWriterLock _namedAsyncReaderWriterLock;
                internal NamedWriterLock(NamedAsyncReaderWriterLock namedAsyncReaderWriterLock)
                {
                    _namedAsyncReaderWriterLock = namedAsyncReaderWriterLock;
                }
                public void Dispose()
                {
                    _namedAsyncReaderWriterLock.ReleaseWriterLock();
                }
            }
        }
