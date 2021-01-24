    public async Task DoWork() 
    {
        var taskList = new List<Task>();
        
        foreach (var thingToDo in work)
        {
           taskList.Add(thingToDo.StartTask());
        }
        await Task.WhenAll(taskList.ToArray());
    }
