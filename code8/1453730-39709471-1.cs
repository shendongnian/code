    //App enter background event
    AppDelegate.Instance.AppDidEnterBackground += delegate {
        TaskManager.Instance.CancelCurrentTaskAndClearTaskQueue();
    };
    //App enter forcenground event
    AppDelegate.Instance.AppWillEnterForeground += delegate {
        if (AppDelegate.FlagForGetData)
    	{
    	    TaskManager.Instance.AddAction(GetData);
    	    TaskManager.Instance.AddAction(GetMoreData);
    	}
    };
