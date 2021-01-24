    public class ViewModelBCreator()
    {
    	private static ViewModelBCreator instance;
    	static ViewModelBCreator() { instance = new ViewModelBCreator(); }
    	private ViewModelBCreator()
    	{
    		Messaging.Messenger.Default.Register<NotificationMessage>(this, true, NotificationMessageReceived);
    	}
    	private static void NotificationMessageReceived(NotificationMessage notification)
    	{
    		var vm = ViewModelB();
    		//Do stuff with the new ViewModelB
    	}
    }  
    
    public class ViewModelB
    { 
    	public ViewModelB()
    	{
    		//etc . . .
    	}
    }
    
    public class ViewModelA
    {
    	public void OpenTheWindow()
    	{
    		Messenger.Default.Send(new NotificationMessage("ShowWindow"));  
    	}
    }
