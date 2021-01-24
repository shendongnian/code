    public ITrigger CreateTrigger(TimeSpan timeSpan, string name = "")
    {
        return TriggerBuilder.Create()
            .StartNow()
            .WithDescription(name)
            .WithSimpleSchedule(x => x
                .WithInterval(timeSpan)
                .RepeatForever())
            .Build();
    }
