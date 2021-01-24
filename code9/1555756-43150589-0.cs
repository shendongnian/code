    public class ViewModelB
    { 
    
    	public ViewModelB()
    	{
    		Messaging.Messenger.Default.Register<NotificationMessage>(this, true, NotificationMessageReceived);
    	}
    	
    	private void NotificationMessageReceived(NotificationMessage notification)
    	{
    		// Handle showing the window here
    	}
    
    }
    
    public class ViewModelA
    {
    
    	public void OpenTheWindow()
    	{
    		Messenger.Default.Send(new NotificationMessage("ShowWindow"));  
    	}
    
    }
