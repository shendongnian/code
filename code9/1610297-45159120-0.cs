    async Task ProcessTasks(IEnumerable<Task> tasks, int numTasks){
        var count = new CountDownEvent(0);
        SemaphoreSlim semaphore = new SemaphoreSlim(numTasks);
        foreach(var task in tasks){
            await semaphore.WaitAsync();
            task.ContinueWith(_=>{
                semaphore.Release();
                count.Signal();
                }
            );
        }
        count.Wait(); // Wait till the count reaches zero
    }
