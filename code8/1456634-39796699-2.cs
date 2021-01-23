    public async Task<bool> Do(int input)
    {
        using(var completion = new new SemephoreSlim(0,1))
        {
            var job = new JobTask(input, completion);
            _workQueue.Add(job);
            await completion.WaitAsync().ConfigureAwait(false);
            return job.ResultData;
        }
    }
    private void ProcessingLoop()
    {
        foreach(var job in _workQueue.GetConsumingEnumerable())
        {
            job.PerformWork(); //Inside PerformWork there is a _completion.Release(); call.
        }
    }
