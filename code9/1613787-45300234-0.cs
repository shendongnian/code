    ThreadPool.QueueUserWorkItem(new WaitCallback(o =>
    {
        var result = getDataFromDatabase();
        Application.Current.Dispatcher.Invoke(() => 
        {
           LstUsers = result;
           IsSplashVisible = false;
        });            
    }));
