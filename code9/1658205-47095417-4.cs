    class TaskWorker : IDisposable
    {
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly SemaphoreSlim _semaphore;
        private readonly int _maxDegreeOfParallelism;
        public TaskWorker(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism));
            }
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
            _semaphore = new SemaphoreSlim(maxDegreeOfParallelism, maxDegreeOfParallelism);
        }
        public async Task RunAsync(Func<Task> taskFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cts.Token))
            {
                // No ConfigureAwait(false) here to keep the SyncContext if any
                // for the real task
                await _semaphore.WaitAsync(cts.Token);
                try
                {
                    await taskFactory().ConfigureAwait(false);
                }
                finally
                {
                    _semaphore.Release(1);
                }
            }
        }
        public async Task<T> RunAsync<T>(Func<Task<T>> taskFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cts.Token))
            {
                await _semaphore.WaitAsync(cts.Token);
                try
                {
                    return await taskFactory().ConfigureAwait(false);
                }
                finally
                {
                    _semaphore.Release(1);
                }
            }
        }
        private void ThrowIfDisposed()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    // consume all semaphore slots
                    for (int i = 0; i < _maxDegreeOfParallelism; i++)
                    {
                        _semaphore.WaitAsync().GetAwaiter().GetResult();
                    }
                    _semaphore.Dispose();
                    _cts.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
