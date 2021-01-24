    ISchedulerFactory sf = new StdSchedulerFactory();
            scheduler = sf.GetScheduler();
            scheduler.Start();
    IJobDetail jobDetail = JobBuilder.Create<HtmlUpdateJob>() // Class of the job
                    .WithIdentity("HtmlUpdateJob") //Name of job
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("UpdateTrigger") // Name of trigger
                    .StartNow()
                    .WithCronSchedule(expr)
                    .Build();
                scheduler.ScheduleJob(jobDetail, trigger);
