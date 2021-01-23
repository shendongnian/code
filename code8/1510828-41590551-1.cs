    /// <summary>
    /// Create a new trigger based on a existing trigger.
    /// </summary>
    /// <param name="oldTrigger">the existing trigger</param>
    /// <param name="startNow">indicates if the trigger should start immediately after schedule</param>
    /// <param name="interval">the interval for the new trigger</param>
    /// <returns>Returns the new trigger</returns>
    public ITrigger CreateTrigger(ITrigger oldTrigger, bool startNow = false, TimeSpan? interval = null)
    {
        var builder = oldTrigger.GetTriggerBuilder();
        if (startNow)
            builder = builder.StartNow();
        if (interval.HasValue)
            builder = builder.WithSimpleSchedule(s => s
                .WithInterval(interval.Value)
                .RepeatForever());
        var newTrigger = builder.Build();
        var simpleTrigger = newTrigger as ISimpleTrigger;
        if(simpleTrigger != null)
        {
            var trigger = oldTrigger as ISimpleTrigger;
            if (trigger != null)
                simpleTrigger.TimesTriggered = trigger.TimesTriggered;
        }
        return newTrigger;
    }
