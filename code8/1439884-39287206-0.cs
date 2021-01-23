    public sealed class MyBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Test.txt", CreationCollisionOption.OpenIfExists);
            System.IO.File.AppendAllText(file.Path, $"{DateTime.Now.ToString()} first activity{Environment.NewLine}");
    
            await Task.Delay(TimeSpan.FromSeconds(90.0));
    
            System.IO.File.AppendAllText(file.Path, $"{DateTime.Now.ToString()} second activity{Environment.NewLine}");
    
            deferral.Complete();
        }
    }
