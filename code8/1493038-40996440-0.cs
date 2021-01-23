    public sealed class MyBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // your task code here
        }
        public void Register()
        {
             RegisterWithTrigger(BackgroundTaskSuffixTime,			new TimeTrigger((uint) RefreshInterval.TotalMinutes, false));
             RegisterWithTrigger(BackgroundTaskSuffixUserPresent,	new SystemTrigger(SystemTriggerType.UserPresent, false));
        }
        
        private static IBackgroundTaskRegistration RegisterWithTrigger(string taskSuffix, IBackgroundTrigger trigger)
		{
			var taskEntryPoint	= typeof(MyBackgroundTask).FullName;
			var taskName		= taskEntryPoint + taskSuffix;
			var registration			= BackgroundTaskRegistration.AllTasks.Select(x => x.Value).FirstOrDefault(x => x.Name == taskName);
			if(registration != null) return registration;
				
			var taskBuilder				= new BackgroundTaskBuilder();
			taskBuilder.Name			= taskName;
			taskBuilder.TaskEntryPoint	= taskEntryPoint;
			taskBuilder.SetTrigger(trigger);
			taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
			return taskBuilder.Register();
		}
    }
