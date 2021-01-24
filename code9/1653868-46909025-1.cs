    public sealed class MyLongRunningBackgroundTask : IBackgroundTask
    {
        BackgroundTaskDeferral deferral;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // We retrieve the deferral to prevent the task to stop
            deferral = taskInstance.GetDeferral();
            // Run loop calling asynchronous methods 
            // It can also be a timer or an event callback registration
            while(true)
            {
                 await doSomethingAsync()
            }
        }
    }
