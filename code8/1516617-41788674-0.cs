    Task[] tasks = new Task[4];
    for (var i = 0; i < tasks.Length; ++i) {
    	tasks[i] = Task.Factory.StartNew(async () =>
    	{
    		await Task.Delay(4000);
    	});
    }
    for (var i = 0; i < tasks.Length; ++i)
    	await await (tasks[i] as Task<Task>);
    
    Console.WriteLine("Done!");
