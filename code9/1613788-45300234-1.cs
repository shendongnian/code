    ThreadPool.QueueUserWorkItem(o =>
    {
        var result = getDataFromDatabase();
        Application.Current.Dispatcher.Invoke(() => 
        {
           LstUsers = result;
           IsSplashVisible = false;
        });            
    });
