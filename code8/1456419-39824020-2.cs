    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        var taskRegistered = false;
        var exampleTaskName = "MyBackgroundTask";
        foreach (var task in BackgroundTaskRegistration.AllTasks)
        {
            if (task.Value.Name == exampleTaskName)
            {
                taskRegistered = true;
                break;
            }
        }
        if (!taskRegistered)
        {
            var builder = new BackgroundTaskBuilder();
            builder.Name = exampleTaskName;
            builder.TaskEntryPoint = "PhoneCallBackground.Class1";
            builder.SetTrigger(new PhoneTrigger(Windows.ApplicationModel.Calls.Background.PhoneTriggerType.CallHistoryChanged, false));
                builder.Register();
        }
    }
