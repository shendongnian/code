    private List<Task<string>> GetSomeWork()
    {
        var tasks = new List<Task<string>>();
    
        tasks.Add(await Task.Run(() => 
                    {
                        Thread.Sleep(3000);
                        return "Message From Task 1";
                    }));
    
        tasks.Add(await Task.Run(() => 
                    {
                        Thread.Sleep(1000);
                        return "Message From Task 2";
                    }));
    
        tasks.Add(await Task.Run(() => 
                    {
                        Thread.Sleep(3000);
                        return "Message From Task 3";
                    }));
    
        return tasks;
    }
    var tasks = GetSomeWork();
    
    while (tasks.Count > 0)
    {
        var task = await Task.WhenAny(tasks);
        var message = task.Result;
        tasks.Remove(task);
    }
