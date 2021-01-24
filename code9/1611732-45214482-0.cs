    crclLoading.Visibility = Visibility.Visible;
    Task.Factory.StartNew(()=> 
    {
        //do something that might take a while here....
        System.Threading.Thread.Sleep(5000);
    }).ContinueWith(task => 
    {
    //and then set the Visibility to Hidden once the task has finished
    crclLoading.Visibility = Visibility.Hidden;
    }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
