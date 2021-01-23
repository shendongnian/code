	using (TaskService ts = new TaskService())
	{
		// If the task exists, remove the trigger. 
        // Note: the included Stop() method doesn't work.
		if (TimerExists(DEFAULT_TASK_NAME))
		{
			Task task = ts.GetTask(DEFAULT_TASK_NAME);
			task.Definition.Triggers.RemoveAt(0);
			task.RegisterChanges();
			StopLocalTimer();    // Resets display timers in program
		}
		else
			throw new NoTimerExists("The timer doesn't exist in the task scheduler. " +
                "You must create it instead of attempting to modify it!");
	}
