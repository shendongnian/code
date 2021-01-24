    private async void Test()
    {
        testbtn.Visibility = Visibility.Visible;
        TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        await Task.Factory.StartNew(() => LoadAll(),
            CancellationToken.None, TaskCreationOptions.None, scheduler);
        testbtn.Visibility = Visibility.Collapsed;
    }
