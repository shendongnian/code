    int nMaxConcurrentTasks = 5;
    public void DoSomethingALotWithTasksThrottled()
    {
        var listOfTasks = new List<Task>();
        for (int i = 0; i < 100; i++)
        {
            var count = i;
            // Note that we create the Task here, but do not start it.
            listOfTasks.Add(new Task(() => Something(count)));
        }
        Tasks.StartAndWaitAllThrottled(listOfTasks, nMaxConcurrentTasks); // 5 max
    }
    public static void StartAndWaitAllThrottled(IEnumerable<Task> tasksToRun, int maxActionsToRunInParallel, CancellationToken cancellationToken = new CancellationToken())
    {
        StartAndWaitAllThrottled(tasksToRun, maxActionsToRunInParallel, -1, cancellationToken);
    }
     
    public static void StartAndWaitAllThrottled(IEnumerable<Task> tasksToRun, int maxActionsToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = new CancellationToken())
    {
        // Convert to a list of tasks so that we don't enumerate over it multiple times needlessly.
        var tasks = tasksToRun.ToList();
     
        using (var throttler = new SemaphoreSlim(maxActionsToRunInParallel))
        {
            var postTaskTasks = new List<Task>();
     
            // Have each task notify the throttler when it completes so that it decrements the number of tasks currently running.
            tasks.ForEach(t => postTaskTasks.Add(t.ContinueWith(tsk => throttler.Release())));
     
            // Start running each task.
            foreach (var task in tasks)
            {
                // Increment the number of tasks currently running and wait if too many are running.
                throttler.Wait(timeoutInMilliseconds, cancellationToken);
     
                cancellationToken.ThrowIfCancellationRequested();
                task.Start();
            }
     
            // Wait for all of the provided tasks to complete.
            // We wait on the list of "post" tasks instead of the original tasks, otherwise there is a potential race condition where the throttler&#39;s using block is exited before some Tasks have had their "post" action completed, which references the throttler, resulting in an exception due to accessing a disposed object.
            Task.WaitAll(postTaskTasks.ToArray(), cancellationToken);
        }
    }
