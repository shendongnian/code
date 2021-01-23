    public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(string.Format("{0} hello this is a test", DateTime.Now.ToString("r")));
            var newInterval = new Random().Next(20, 30);
            // retrieve the trigger
            var oldTrigger = context.Scheduler.GetTrigger(new TriggerKey("simpleTrigger", "simpleTriggerGroup"));
            // obtain a builder that would produce the trigger
            var tb = oldTrigger.GetTriggerBuilder();
            // update the schedule associated with the builder, and build the new trigger
            var newTrigger = tb.StartAt(DateTime.Now.AddSeconds(newInterval)).Build();
            context.Scheduler.RescheduleJob(oldTrigger.Key, newTrigger);
            Console.WriteLine("Trigger fired... changed interval to {0}", newInterval);
        }
