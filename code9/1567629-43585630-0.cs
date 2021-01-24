    Task t = Task.Factory.StartNew(() =>
    {
        return GetData(true);  // <-- GetData should return a collection of objects
    }).ContinueWith(task =>
    {
        //that you add to your ObservableCollection here:
        foreach (var item in task.Result)
            yourObservableCollection.Add(item);
    },
    System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
