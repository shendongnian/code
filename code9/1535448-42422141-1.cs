    public class Foo
    {
    	private static object _barLock = new object();
    	private IBar bar;
    	public IBar Bar
    	{
    		get
    		{
    			lock (_barLock)
    			{
    				return bar;
    			}
    		}
    		set
    		{
    			lock (_barLock)
    			{
    				bar = value;
    			}
    		}
    	}
    
    	public void UpdateBar(IBar bar2)
    	{
    		Bar = bar2;
    	}
    
    	public void DoStuffWithBar()
    	{
    		Bar.DoStuff();
    	}
    }
