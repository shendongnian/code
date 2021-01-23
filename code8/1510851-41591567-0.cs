    Task.Run(() =>
    {
        //...
        foreach (var file in listOfFiles)
        {
            //...
            progressWindow.Dispatcher.Invoke(new Action(()=> progressWindow.IncremntProgress()));
        }
    }).ContinueWith(task => 
    {
        progressWindow.Close();
    }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
