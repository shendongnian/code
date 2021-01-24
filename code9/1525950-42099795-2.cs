	public async Task RunConcurrentTasks()
	{
		// starts DoSomethingAsync and returns a Task which contains the information about the running state of that operation
		// the thread that called this gets that Task as a result immediatly and can continue on to the next statement while this is running
		var firstTask = DoSomethingAsync();
		
		// starts DoSomethingElseAsync and returns a Task which contains the information about the running state of that operation
		// the thread that called this gets that Task as a result immediatly and can continue on to the next statement while this is running
		var secondTask = DoSomethingElseAsync();
		// suspend the execution of the method until the awaited task completes
		// only then do we proceed to the next line (assuming no exception was thrown)
		await firstTask;
		// suspend the execution of the method until the awaited task completes
		// only then do we proceed to the next line (assuming no exception was thrown)
		await secondTask;
	} 
	public async Task RunConcurrentTasks()
	{
		// starts DoSomethingAsync and returns a Task which contains the information about the running state of that operation
		// the thread that called this gets that Task as a result immediatly and can continue on to the next statement while this is running
		var firstTask = DoSomethingAsync();
		
		// starts DoSomethingElseAsync and returns a Task which contains the information about the running state of that operation
		// the thread that called this gets that Task as a result immediatly and can continue on to the next statement while this is running
		var secondTask = DoSomethingElseAsync();
		// suspend the execution of the method until the awaited DoSomethingAsync AND DoSomethingElseAsync have completed
		// only then do we proceed to the next line (assuming no Exceptions was thrown)
		await Task.WhenAll(firstTask, secondTask);
	}
