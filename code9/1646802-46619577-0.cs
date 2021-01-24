    public static class Extension
    {
        public static async Task ExecuteAsync<T>(this IEnumerable<T> items, Func<T, Task> task, int concurrency)
        {
            var tasks = new List<Task>();
            using (var semaphore = new SemaphoreSlim(concurrency))
            {
                foreach (var item in items)
                {
                    tasks.Add(ExecuteInSemaphore(semaphore, task, item));
                }
                await Task.WhenAll(tasks);
            }
        }
        private static async Task ExecuteInSemaphore<T>(SemaphoreSlim semaphore, Func<T, Task> task, T item)
        {
            await semaphore.WaitAsync();
            try
            {
                await task(item);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
