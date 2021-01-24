    public static Task SynchronousTask(List<Action> actions)
    {
        var initialTask = new Task(() => autoResetEvent.WaitOne());
        Task lastTask = initialTask;
        for (int i = 0; i < actions.Count; i++)
        {
            int i1 = i;
            lastTask = lastTask.ContinueWith(task => actions[i1]()); // here
        }
        lastTask.ContinueWith(task => autoResetEvent.Set());
        initialTask.Start();
        return initialTask;
    }
