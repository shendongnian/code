    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 10; i++)
    {
        // capture taskid here
        int taskid = (int)i;
        Task t = Task.Factory.StartNew((arg) =>
        {
            IteratingFunction(taskid);
        }, i);
        tasks.Add(t);
    }
    Task.WaitAll(tasks.ToArray());
