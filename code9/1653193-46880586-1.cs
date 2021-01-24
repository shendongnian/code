    List<Task> tasks = new List<Task>();
    int counter = 0; // not sure what this is for
    
    foreach (var user in users)
    {
        tasks.Add(user.SendNotificationAsync()); // do not create a wrapping task
        counter++; // not sure about this either
        
        // it won't ever be greater than 20
        if (tasks.Count == 20)
        {
            await Task.WhenAll(tasks);
            tasks.Clear();
        }
    }
    
    if (tasks.Any())
    {
        await Task.WhenAll(tasks);
        tasks.Clear();
    }
