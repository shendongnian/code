    NameValueCollection props = new NameValueCollection
    {
        { "quartz.serializer.type", "binary" }
    };
    StdSchedulerFactory factory = new StdSchedulerFactory(props);
    var scheduler = await factory.GetScheduler();
    var tokenSource = new CancellationTokenSource();
    CancellationToken ct = tokenSource.Token;
    await scheduler.Start();
    IJobDetail job = JobBuilder.Create<HelloJob>()
        .WithIdentity("myJob", "group1")
        .Build();
    ITrigger trigger = TriggerBuilder.Create()
        .WithIdentity("myTrigger", "group1")
        .StartNow()
        .WithSimpleSchedule(x => x
            .WithRepeatCount(1)
            .WithIntervalInSeconds(40))
        .Build();
    await scheduler.ScheduleJob(job, trigger);
    //Configure the cancellation of the schedule job with jobkey
    await scheduler.Interrupt(job.Key, ct);
    await Task.Delay(TimeSpan.FromSeconds(5));
    tokenSource.Cancel();//Cancel the job
