    public class ViewModelB
    { 
    
    	static ViewModelB()
    	{
			//Static Constructor
    		Messaging.Messenger.Default.Register<NotificationMessage>(null, true, NotificationMessageReceived);
    	}
    	
    	private static void NotificationMessageReceived(NotificationMessage notification)
    	{
    		var vm = ViewModelB();
    		//Do stuff with the new ViewModelB
    	}
    	public ViewModelB()
    	{
    		//Actual constructor
    	}
    
    }
    
    public class ViewModelA
    {
    
    	public void OpenTheWindow()
    	{
    		Messenger.Default.Send(new NotificationMessage("ShowWindow"));  
    	}
    
    }
