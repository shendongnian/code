    var actions = new [] { action, action, action, action, action, action, action, action };
    var tasks = new Task[actions.Length];
    for (int index = 1; index < tasks.Length; ++index)
        tasks[index] = Task.Factory.StartNew(actions[index]);
    tasks[0] = new Task(actions[0]);
    tasks[0].RunSynchronously();
    Task.WaitAll(tasks);
