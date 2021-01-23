    // get the trigger
    var trigger = Scheduler.GetTrigger(new TriggerKey("trigger1", "group1"));
    // get your settings and set the interval
    var reminderSettings = GetReminderSettings();
    var intervalBtwnReminders = 0;
    if (reminderSettings?.RemindersGap != null)
    {
        intervalBtwnReminders = (int)(reminderSettings.RemindersGap);         
    }
    // reschedule the job with a new trigger and start it immediately.
    // if you don't want that it starts now, pass 'false' for the 'startNow' parameter
    Scheduler.RescheduleJob(trigger.Key, CreateTrigger(trigger, true, TimeSpan.FromMinutes(intervalBtwnReminders)));
