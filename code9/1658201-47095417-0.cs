    class TaskWorker
    {
        private readonly SemaphoreSlim _semaphore;
        public TaskWorker(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism));
            }
            _semaphore = new SemaphoreSlim(maxDegreeOfParallelism, maxDegreeOfParallelism);
        }
        public async Task RunAsync(Func<Task> taskFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            // No ConfigureAwait(false) here to keep the SyncContext if any
            // for the real task
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                await taskFactory().ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release(1);
            }
        }
        public async Task<T> RunAsync<T>(Func<Task<T>> taskFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _semaphore.WaitAsync(cancellationToken);
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
