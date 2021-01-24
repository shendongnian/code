    public class Wrapper<T>
    {
    	private Action<T> _doCalc { get; set; }
    	
    	public Wrapper(Action<T> doCalc)
    	{
    		_doCalc = doCalc;
    	}
    
    	public T Value { get; set; }
    	
    	public void DoCalc()
    	{
    		_doCalc(this.Value);
    	}
    }
