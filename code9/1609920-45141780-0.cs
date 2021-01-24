    internal async object ExecuteJobAsync(RequestParam inputParam)
    {
        bool jobStatus = false;
        var result = await jobManager.ExecuteJob(inputParam);
        // Code continues
    }
    public Task<int> ExecuteJob(RequestParam param)
    {
         return Task.Run<int>(() =>
         {
             return (int)package.Execute();
         });
    }
