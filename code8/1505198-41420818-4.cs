	using (TaskService ts = new TaskService())
	{
		// If the task exists, update the trigger.
		if (TimerExists(DEFAULT_TASK_NAME))
		{
			Task task = ts.GetTask(DEFAULT_TASK_NAME);
			if (task.Definition.Triggers.Count == 1)
				task.Definition.Triggers.RemoveAt(0);
			else if (task.Definition.Triggers.Count > 1)
			{
				for (int index = 0; index < task.Definition.Triggers.Count - 1; index++)
				{
					task.Definition.Triggers.RemoveAt(index);
				}
			}
			// Add the new trigger after making sure it is the only one.
			task.Definition.Triggers.Add(new TimeTrigger(_shutdownTime));
			if (task.Definition.Actions.Count == 1)
				task.Definition.Actions.RemoveAt(0);
			else if (task.Definition.Actions.Count > 1)
			{
				for (int index = 0; index < task.Definition.Actions.Count - 1; index++)
				{
					task.Definition.Actions.RemoveAt(index);
				}
			}
			// Add the new action after making sure it is the only one.
			task.Definition.Actions.Add(new ExecAction("shutdown", SHUTDOWN_COMMAND_ARGS, 
            null));
			// Reset the status in case it was set as anything but "Ready"
			task.Definition.Settings.Enabled = true;
			task.RegisterChanges();
			Properties.Settings.Default.ShutdownTimer = _shutdownTime;
			Properties.Settings.Default.Save();
            
            // Starts the timer display and enables/disables buttons.
			StartLocalTimer();
		}
		else
			throw new NoTimerExists("The timer doesn't exist in the task scheduler. You " +
            "must create it instead of attempting to modify it!");
	}
