    ISet<Task<bool>> activeTasks = new HashSet<Task<bool>>(myTasks);
    while (activeTasks.Count > 0)
    {
        Task<bool> completed = await Task.WhenAny(activeTasks);
        if (completed.Status == TaskStatus.RanToCompletion &&
            completed.Result)
        {
            // Or take whatever action you want
            return;
        }
        // Task was faulted, cancelled, or had a result of false.
        // Go round again.
        activeTasks.Remove(completed);
    }
    // No successful tasks - do whatever you need to here.
