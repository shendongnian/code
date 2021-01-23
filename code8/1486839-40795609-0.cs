    public static async Task<bool> RegisterInProcessBackgroundTask(string taskName, uint time = 30) {
        try {
            await BackgroundExecutionManager.RequestAccessAsync();
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
            taskBuilder.Name = taskName;
            taskBuilder.SetTrigger(new TimeTrigger(time, false));
            BackgroundTaskRegistration registration = taskBuilder.Register();
            return true;
        } catch {
            return false;
        }
    }
