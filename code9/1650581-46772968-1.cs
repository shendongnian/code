      public void StartTrigger()
            {
                try
                {
                    IScheduler sched = Start();
                    IJobDetail Job = JobBuilder.Create<Job>().WithIdentity("Job", null).Build();
                    ISimpleTrigger TriggerJob =
                                       (ISimpleTrigger)TriggerBuilder
                                       .Create()
                                       .WithIdentity("Job")
                                       .StartAt(DateTime.UtcNow)
                                       .WithSimpleSchedule(x => x
                                       .WithIntervalInSeconds(1)
                                       .RepeatForever()
                                       //.WithRepeatCount(4)
                                       .WithMisfireHandlingInstructionNextWithExistingCount())
                                       .Build();
                    sched.ScheduleJob(Job, TriggerJob);
                    sched.Start();
                    Thread.Sleep(4T000);
                    sched.Shutdown();
                }
