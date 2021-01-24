    DateTime alarmTime = DateTime.Now.AddMinutes(1);
     
    // Only schedule notifications in the future
    // Adding a scheduled notification with a time in the past
    // will throw an exception.
    if (alarmTime > DateTime.Now.AddSeconds(5))
    {
        // Generate the toast content (from previous steps)
        ToastContent toastContent = GenerateToastContent();
     
        // Create the scheduled notification
        var scheduledNotif = new ScheduledToastNotification(
            toastContent.GetXml(), // Content of the toast
            alarmTime // Time we want the toast to appear at
            );
     
        // And add it to the schedule
        ToastNotificationManager.CreateToastNotifier().AddToSchedule(scheduledNotif);
    }
