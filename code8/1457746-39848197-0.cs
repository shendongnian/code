    sealed partial class App : Application
    {
        /// <summary>
        /// Override the Application.OnBackgroundActivated method to handle background activation in 
        /// the main process. This entry point is used when BackgroundTaskBuilder.TaskEntryPoint is 
        /// not set during background task registration.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            //TODO
        }
    }
