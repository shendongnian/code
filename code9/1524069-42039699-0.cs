    pb.Visibility = Visibility.Visible;
    Task.Run(()=> 
    {
        //perform your long-running operation here...make sure that you don't access any UI elements
        Save();
    })
    .ContinueWith(task => 
    {
        //this delegate will be executed back on the UI thread once the task has finished because of the scheduler returned from the TaskScheduler.FromCurrentSynchronizationContext() method...
        pb.Visibility = Visibility.Collapsed;
    }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
