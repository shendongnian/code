    private bool _initializationIsScheduled = false;
    private object _initializationIsScheduledLock = new object();
    private bool _isInitialized = false;
    private object _isInitializedLock = new object();
    private async Task EnqueueAndProcessJobs(int taskId, int jobId)
    {
        var shouldDoHeavyWork = false;
        lock(_initializationIsScheduledLock)
        {
            if (!_initializationIsScheduled)
            {
                shouldDoHeavyWork = true;
                _initializationIsScheduled= true;
            }
        }
        if (shouldDoHeavyWork)
        {
            await OneTimeInitAsync(taskId);
            lock (_isInitializedLock)
            {
                _isInitialized = true;
            }
        }
        lock (_isInitializedLock)
        {
            if (_isInitialized)
            {
                shouldDoHeavyWork = true;
            }
        }
        if (shouldDoHeavyWork)
        {
            await ProcessQueueAsync(taskId);
        }
        Console.WriteLine($"Task {taskId} completed.");
    }
