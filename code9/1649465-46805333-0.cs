    private List<IResult> CollectResults(IEnumerable<IItem> collection, int maximumProcessingMilliseconds )
    {
        List<IResult> results = new List<IResult>();
        CancellationTokenSource cts = new CancellationTokenSource();
        cts.CancelAfter(maximumProcessingMilliseconds);
        var tasks = new List<Task<IResult>>();
        foreach (IItem item in collection)
        {
            IItem localItem = item;
            tasks.Add(Task.Run(() => localItem.GetResult(cts.Token), cts.Token));
        }
        Task[] tasksArray = tasks.ToArray();
        try
        {
            Task.WaitAll(tasksArray, TimeSpan.FromMilliseconds(maximumProcessingMilliseconds));
            Task.WaitAll(tasksArray);
        }
        catch (AggregateException ex)
        {
            Logger.LogException(ex);
        }
        foreach (Task<IResult> task in tasks)
        {
            if (task.Status == TaskStatus.RanToCompletion)
            {
                results.Add(task.Result);
            }
        }
        return results;
    }
