    private void RegisterBackgroundTasks()
    {
      BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
      builder.Name = "Background Test Class";
      builder.TaskEntryPoint = "BackgroundTaskLibrary.TestClass";
      IBackgroundTrigger trigger = new TimeTrigger(30, true);
      builder.SetTrigger(trigger);
      IBackgroundCondition condition =
        new SystemCondition(SystemConditionType.InternetAvailable);
      builder.AddCondition(condition);
      IBackgroundTaskRegistration task = builder.Register();
      task.Progress += new BackgroundTaskProgressEventHandler(task_Progress);
      task.Completed += new BackgroundTaskCompletedEventHandler(task_Completed);
    }
