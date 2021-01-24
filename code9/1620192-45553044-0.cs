    Task.Run(() => MyAwesomeMethod()).ContinueWith((task) =>
    {
    	if (task.Status == TaskStatus.RanToCompletion && task.Result != null)
    	{
    	
    	}
    	else
    	{
    		try
    		{
    			Logger.LogError(task.Exception.ToString());
    			Logger.LogMessage("something_went_wrong");
    		}
    		catch { }
    	}
    });
