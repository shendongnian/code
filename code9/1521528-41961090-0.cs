    public void OnLoad()
    {
        StartRunning(this, null);
        Task.Factory.StartNew(new Action(() =>
        {
            Load();
        })).ContinueWith(task =>
        {
            SelectedItem = Results[0];
            StopRunning(this, null);
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
