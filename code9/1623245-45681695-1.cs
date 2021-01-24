    public interface IResult {... }
    
    public class ConcreteResult : IResult {...}
    
    
    public class MyStartServiceCallbackInfo
    {
    	public MyAPI.MyAPIDelegate Callback1 { get; set; }
    	public MyAPI.MyAPIDelegate Callback2 { get; set; }
    	public MyAPI.MyAPIDelegate Callback3 { get; set; }
    }
    
    
    public class MyAPI
    {
    	public delegate void MyAPIDelegate(IResult result);
    
    	public void StartService(MyStartServiceCallbackInfo callbacks)
    	{
    		...
    		callbacks?.Callback1(result1);
    		...
    		callbacks?.Callback2(result2);
    		...
    		callbacks?.Callback3(result3);
    	}
    
    	public void main()
    	{
    		StartService(new MyCallbackInfo()
    		{
    			Callback1 = developerCallback,
    			Callback2 = developerCallback2,			
    		});
    	}
    	private void developerCallback(IResult result)
    	{
    		Console.WriteLine(result.i);
    	}
    	private void developerCallback2(IResult result)
    	{
    		Console.WriteLine(result.i);
    	}
    }
