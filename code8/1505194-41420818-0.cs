    using (TaskService ts = new TaskService())
	{
		// If the task doesn't exist, create it.
		if (TimerExists(DEFAULT_TASK_NAME))
			throw new TimerExists("The timer already exists in the task scheduler. You " +
            "must modify it instead of attempting to create it!");
		else
		{
			try
			{
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Date = _currentTime;    // DateTime.Now
				td.RegistrationInfo.Source = "Windows Shutdown Timer";
				td.RegistrationInfo.Description = "Shutdown Timer initiated Windows " + 
                    "Shutdown Timer";
				td.Settings.Enabled = true;
				td.Triggers.Add(new TimeTrigger(_shutdownTime));
				td.Actions.Add(new ExecAction("shutdown", SHUTDOWN_COMMAND_ARGS, null));
				
				TaskService.Instance.RootFolder
                           .RegisterTaskDefinition(DEFAULT_TASK_NAME,td);
				Properties.Settings.Default.ShutdownTimer = _shutdownTime;
				Properties.Settings.Default.Save();
				StartLocalTimer();
			}
			catch(Exception)
			{
				DialogResult alert = MessageBox.Show("The timer couldn't be set. ", 
                    "Error - Couldn't Set Timer!", MessageBoxButtons.RetryCancel, 
                     MessageBoxIcon.Error);
				if (alert == DialogResult.Retry)
					CreateShutdownTimer(numSeconds);
			}
		}
	}
