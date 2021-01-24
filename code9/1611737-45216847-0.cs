    async Task Main()
    {
        ReportLockProvider reportLockProvider = new ReportLockProvider();
        List<Task> tasks = new List<Task>(10);
    
        for (long i = 1; i <= 5; i++) {
            var local = i;
            tasks.Add(Task.Run(() => Enter(local) ));
            tasks.Add(Task.Run(() => Enter(local) ));
        }
    
        async Task Enter(long id)
        {
            Console.WriteLine(id + " waiting to enter");
            await reportLockProvider.WaitAsync(id);
    
            Console.WriteLine(id + " entered!");
            Thread.Sleep(1000 * (int)id);
    
            Console.WriteLine(id + " releasing");
            reportLockProvider.Release(id);
        }
    
        await Task.WhenAll(tasks.ToArray());
    }
    
    public class ReportLockProvider
    {
        static readonly ConcurrentDictionary<long, SemaphoreSlim> lockDictionary = new ConcurrentDictionary<long, SemaphoreSlim>();
    
        public async Task WaitAsync(long reportId)
        {
            await lockDictionary.GetOrAdd(reportId, new SemaphoreSlim(1, 1)).WaitAsync();
        }
        public void Release(long reportId)
        {
            SemaphoreSlim semaphore;
            if (lockDictionary.TryGetValue(reportId, out semaphore))
            {
                semaphore.Release();
            }
        }
    }
