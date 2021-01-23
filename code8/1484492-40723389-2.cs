    public static async Task WhenAll(this List<Func<Task>> actions, int threadCount)
    {
        var executeTaskHelper = new ConcurrentTaskHelper(threadCount);
        return executeTaskHelper.Execute(actions);
    }
    public class ConcurrentTaskHelper
    {
        int _threadCount;
        CountdownEvent _countdownEvent;
        SemaphoreSlim _throttler;
        public ConcurrentTaskHelper(int threadCount)
        {
            _threadCount = threadCount;
             _throttler  = new SemaphoreSlim(threadCount);
        }
        public async Task Execute(List<Func<Task>> tasks)
        {
            _countdownEvent = new CountdownEvent(tasks.Count);
            foreach (var task in tasks)
            {
                await _throttler.WaitAsync();
                Execute(task);
            }
            _countdownEvent.Wait();
        }
        private async Task Execute(Func<Task> task)
        {
            try { await task(); }
            finally { Completed(); }
        }
        private void Completed()
        {
            _throttler.Release();
            _countdownEvent.Signal();
        }
    }
