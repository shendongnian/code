        public class MySampleAppService
        {
                private readonly IAbpQuartzConfiguration _abpQuartzConfiguration;
                public MySampleAppService(IAbpQuartzConfiguration abpQuartzConfiguration)
            	{
            	   _abpQuartzConfiguration = abpQuartzConfiguration
            	}
            
            	private void ListAllJobs()
            	{
            		var scheduler = _abpQuartzConfiguration.Scheduler;
            		var jobGroups = scheduler.GetJobGroupNames();
            		foreach (string group in jobGroups)
            		{
            			var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
            			var jobKeys = scheduler.GetJobKeys(groupMatcher);
            			foreach (var jobKey in jobKeys)
            			{
            				var detail = scheduler.GetJobDetail(jobKey);
            				var triggers = scheduler.GetTriggersOfJob(jobKey);
            				foreach (ITrigger trigger in triggers)
            				{
            					Console.WriteLine(group);
            					Console.WriteLine(jobKey.Name);
            					Console.WriteLine(detail.Description);
            					Console.WriteLine(trigger.Key.Name);
            					Console.WriteLine(trigger.Key.Group);
            					Console.WriteLine(trigger.GetType().Name);
            					Console.WriteLine(scheduler.GetTriggerState(trigger.Key));
            
            					var nextFireTime = trigger.GetNextFireTimeUtc();
            					if (nextFireTime.HasValue)
            					{
            						Console.WriteLine(nextFireTime.Value.LocalDateTime.ToString(CultureInfo.InvariantCulture));
            					}
            
            					var previousFireTime = trigger.GetPreviousFireTimeUtc();
            					if (previousFireTime.HasValue)
            					{
            						Console.WriteLine(previousFireTime.Value.LocalDateTime.ToString(CultureInfo.InvariantCulture));
            					}
            				}
            			}
            		}
            	}
          //...
    }
