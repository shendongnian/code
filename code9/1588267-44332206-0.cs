    private void Do()
    {
        IsLoading = true;
        Task.Factory.StartNew(() =>
        {
            //this operation is performed on a background thread...
            Thread.Sleep(1000);
        }).ContinueWith(task =>
        {
            IsLoading = false;
        }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
