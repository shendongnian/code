    public class AsynchronousWrapper
    {
        private static SemaphoreSlim _mutex = new SemaphoreSlim(1);
    
        public async Task<T> ProcessAsync<T>(Task<T> arg)
        {
            await _mutex.WaitAsync().ConfigureAwait(false);
    
            try
            {
                return await arg;
            }
            finally
            {
                _mutex.Release();
            }
        }
    }
