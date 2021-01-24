    public class MyThing
    {
    	private Action<MyThing> _doCalc { get; set; }
    
    	public MyThing(Action<MyThing> doCalc)
    	{
    		_doCalc = doCalc;
    
    	}
    
    	public void DoCalc()
    	{
    		_doCalc(this);
    	}
    	
    	public string SomeString { get; set; }
    }
