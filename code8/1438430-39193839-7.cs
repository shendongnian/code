    ConcurrentBag<AsyncLazy<Task>> taskList = new ConcurrentBag<AsyncLazy<Task>>();
    void Main()
    {
    	int v = 3242;
    	AsyncLazy<Task> objAsyncLazy = null;
    	objAsyncLazy = new AsyncLazy<Task>(new Func<Task<Task>>(async () =>
       {
    	   return await Task.FromResult<Task>(doLongRunningAsync(v).
    					ContinueWith<Task>(async (doLongRunningAsyncCompletedTask) =>
    				   {
    					   Console.WriteLine(doLongRunningAsyncCompletedTask.IsCompleted); // 
    					   await removeMeFromListAsync(objAsyncLazy);
    				   }));
       }));
    
    	taskList.Add(objAsyncLazy);
    	Console.WriteLine("al added");
    	Console.WriteLine("ConcurrentBag.Count: " + taskList.Count);
    	// execute the task
    	var t = objAsyncLazy.GetValueAsync(System.Threading.CancellationToken.None);
    	t.Wait(); // wait for the first task to finish or not
    	// ContinueWith is executing now
    	Console.ReadLine();
    }
    
    public async Task doLongRunningAsync(int val)
    {
    	Console.WriteLine("Before delay" + val);
    	await Task.Delay(1000);
    	Console.WriteLine("After delay");
    }
    
    public async Task removeMeFromListAsync(AsyncLazy<Task> al) //(AsyncLazy<Task> t)
    {
    	Console.WriteLine("continue start");
    	taskList.TryTake(out al);
    	Console.WriteLine("al removed");
    	Console.WriteLine("ConcurrentBag.Count: " + taskList.Count);
    	await Task.Delay(1000);
    	Console.WriteLine("continue end");
    }
    }
