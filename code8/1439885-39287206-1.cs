    public sealed class MyBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Test.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(file, $"{DateTime.Now.ToString()} first activity{Environment.NewLine}");
    
            await Task.Delay(TimeSpan.FromSeconds(90.0));
    
            await FileIO.AppendTextAsync(file, $"{DateTime.Now.ToString()} second activity{Environment.NewLine}");
    
            deferral.Complete();
        }
    }
