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
                // if we have more than 4 tasks in progress (not completed yet), we start processing some of the completed tasks
                // this will await any of the current tasks to complete, them process it (and any other task which may have been completed as well)...
                await ProcessRealCombinations().ConfigureAwait(false);
            }
        }
        // wait until all the last tasks have been completed...
        while(this._tasks.Any())
            await ProcessRealCombinations().ConfigureAwait(false);
        return this._combinationsReal;
    }
