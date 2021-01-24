    public class TaskLimiter
    {
        private readonly TimeSpan _timespan;
        private readonly SemaphoreSlim _semaphore;
        public TaskLimiter(int count, TimeSpan timespan)
        {
            _semaphore = new SemaphoreSlim(count, count);
            _timespan = timespan;
        }
        public async Task LimitAsync(Func<Task> taskFactory)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            var task = taskFactory();
            task.ContinueWith(async e =>
            {
                await Task.Delay(_timespan);
                _semaphore.Release(1);
            });
            await task;
        }
        public async Task<T> LimitAsync<T>(Func<Task<T>> taskFactory)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            var task = taskFactory();
            task.ContinueWith(async e =>
            {
                await Task.Delay(_timespan);
                _semaphore.Release(1);
            });
            return await task;
        }
    }
