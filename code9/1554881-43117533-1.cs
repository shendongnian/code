    if (e.Key == Key.Delete)
    {
        Window window = new Window();
        window.Show();
        Task.Factory.StartNew(() => ExecuteLongMethod())
        .ContinueWith(task => 
        {   
            window.Close();
        },System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
