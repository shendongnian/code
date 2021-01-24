    Task.Factory.StartNew(()=> 
    {
        //get the files on a background thread...
        return Directory.EnumerateFiles(DirName, Ext, SearchOption.TopDirectoryOnly);
    }).ContinueWith(task => 
    {
        //this code runs back on the UI thread
        IEnumerable<string> theFiles = task.Result; //...
    }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
