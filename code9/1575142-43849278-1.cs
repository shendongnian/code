    private void ProcessNotificationsWithExceptionHandling()
    {
    	try
    	{
    		ProcessNotifications();
    	}
    	catch(Exception ex)
    	{
    		GenerateNotification();
            //Log Something here
    	}
    }
    
