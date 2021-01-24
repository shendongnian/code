    public async Task<string> AllReadLineAsync()
    {
        var tasklist = new List<Task<string>>();
    
        foreach (var client in clients)
            tasklist.Add(client.ReadLineAsync());
    
        while (tasklist.Count > 0)
        {
            Task<string> finishedTask = await Task.WhenAny(tasklist);
            if (finishedTask.Status == TaskStatus.RanToCompletion)
                return await finishedTask;
    
            tasklist.Remove(finishedTask);
        }
    
        return "Error: No task finished";
    }
