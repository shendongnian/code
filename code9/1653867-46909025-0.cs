    public sealed class MyLongRunningBackgroundTask : IBackgroundTask
    {
        BackgroundTaskDeferral deferral;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // We retrieve the deferral to prevent the task to stop
            deferral = taskInstance.GetDeferral();
            while(true)
            {
                 await doSomethingAsync()
            }
        }
    }
