    public enum StartType
    {
    	Auto = 0,
    	Manual = 1
    }
    
    public class MyUserControlA
    {
    	public TimeStartType
    	{
    		{get;set;}
    	}
    }
    
    public class MyUserControlB
    {
    	public TimeStartType
    	{
    		{get;set;}
    	}
    }
    
    public class MainPage : Page
    {
    	MyUserControlA controla = new MyUserControlA();
    	
    	MyUserControlB controlb = new MyUserControlB();
    	
    	controla.TimeStartType = StartType.Auto;
    	
    	controlb.TimeStartType = StartType.Manual;
    }
