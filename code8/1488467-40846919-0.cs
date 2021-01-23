    Task.WhenAll(tasks).Wait();
    Foreach(Task task in tasks)
    {
        if(task.IsCanceled)
            Console.WriteLine("Tasks canceled");
        if(task.IsCompleted)
            Console.WriteLine("Tasks completed");
    }
