    private bool _initializationIsScheduled = false;
    private bool _isInitialized = false;
    private async Task EnqueueAndProcessJobs(int taskId, int jobId)
    {
        var shouldDoHeavyWork = false;
        if (!_initializationIsScheduled)
        {
            lock(_initializationIsScheduled)
            {
                if (!_initializationIsScheduled)
                {
                    shouldDoHeavyWork = true;
                    _initializationIsScheduled= true;
                }
            }
        }
        if (shouldDoHeavyWork)
        {
            await OneTimeInitAsync(taskId);
            lock (_isInitialized)
            {
                _isInitialized = true;
            }
        }
        lock (_isInitialized)
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
