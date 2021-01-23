    public static bool PerformTask()
	{
		WaitCallback taskCallback = null;
		object task = null;
		// Use TryEnter, rather than "lock" because 
        // it allows us to specify a timeout as a failsafe.
		if(Monitor.TryEnter(locker, 500))
		{
			try 
			{
				// Pull a task from the queue.
				if(taskQueue.Count > 0)
				{
					task = taskQueue.Dequeue();
				}
				if(taskCallbacks.Count > 0)
				{
					taskCallback = taskCallbacks.Dequeue();
				}
			}
			finally
			{
				Monitor.Exit(locker);
			}
		}
		// No task means no work, return false.
		if(task == null || taskCallback == null) { return false; }
		// Do the work!
		taskCallback(task);
		return true;
	}
