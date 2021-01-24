    public interface IResult
    {
    	int i { get; set; }
    }
    
    public class ConcreteResult : IResult
    {
    	public int i
    	{
    		get; set;
    	}
    }
    
    
    public class MyCallbackInfo
    {
    	public MyAPI.MyAPIDelegate Callback1 { get; set; }
    	public MyAPI.MyAPIDelegate Callback2 { get; set; }
    	public MyAPI.MyAPIDelegate Callback3 { get; set; }
    }
    
    
    public class MyAPI
    {
    	public delegate void MyAPIDelegate(IResult result);
    
    	public void StartService(MyCallbackInfo callbacks)
    	{
    		//step 1
    		int i = 0;
    		ConcreteResult result1 = new ConcreteResult();
    		result1.i = i;
    		callbacks?.Callback1(result1);
    		//step 2
    		i += 1;
    		ConcreteResult result2 = new ConcreteResult();
    		result2.i = i;
    		callbacks?.Callback2(result2);
    		//potentially added in the future
    		//i += 1;
    		//callback3();
    		callbacks?.Callback3(result3);
    	}
    
    	public void main()
    	{
    		//developers use my API
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
