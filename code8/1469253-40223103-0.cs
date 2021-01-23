    List<Task> tasks = new List<Task>();
    foreach (var obj in myObjs)
    {
        tasks.Add(policy.ExecuteAsync(() => Task.Factory.StartNew(() => obj.Do(), TaskCreationOptions.LongRunning)));
    }
    
    // sometime later
    await Task.WhenAll(tasks);
