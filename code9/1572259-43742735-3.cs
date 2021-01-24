    async Task InfiniteLoopThatExecutesTasksOneByOne()
    {
        while(true)
        {
            WorkItem item = null;
            await LockQueueAsync();
            item = InspectTheQueueAndSkipSomethingIfNeeded();
            UnlockQueue();
            if(item!=null)
            await DispatchItemToUIThread(item);
            await Task.Delay(delay);
        }
    }
    
