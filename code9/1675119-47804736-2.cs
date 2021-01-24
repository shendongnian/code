    ISchedulerFactory sf = new StdSchedulerFactory();
            scheduler = sf.GetScheduler();
            scheduler.Start();
    IJobDetail jobDetail = JobBuilder.Create<HtmlUpdateJob>() // Class of the job
                    .WithIdentity("HtmlUpdateJob") //Name of job
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("UpdateTrigger") // Name of trigger
                    .StartNow()
                    .WithCronSchedule("0 0/60 * 1/1 * ? *") //every 60 mins
                    .Build();
                scheduler.ScheduleJob(jobDetail, trigger);
