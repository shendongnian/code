    public async Task<Dictionary<string, CalculationResult>> Execute()
    {
        ConcurrentBag<Dictionary<string, CalculationResult>> results = new ConcurrentBag<Dictionary<string, CalculationResult>>();
            
        for (int i = 0; i < this._codes.Count(); i++)
        {
            // start the task imediately
            var task = ProcessCombinations();
            this._tasks.Add(task);
            if (this._tasks.Count() >= MAX_CONCURRENT_TASKS)
            {
                // if we have more than MAX_CONCURRENT_TASKS in progress, we start processing some of them
                // this will await any of the current tasks to complete, them process it (and any other task which may have been completed as well)...
                await ProcessCompletedTasks().ConfigureAwait(false);
            }
        }
        // keep processing until all the pending tasks have been completed...it should be no more than MAX_CONCURRENT_TASKS
        while(this._tasks.Any())
            await ProcessCompletedTasks().ConfigureAwait(false);
        return this._combinationsReal;
    }
