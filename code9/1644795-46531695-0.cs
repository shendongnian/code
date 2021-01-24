    public delegate void MyHandler<T>(IMyInterface<T> pParam);
    
    public interface IMyInterface<T>
    {
    	MyHandler<T> EventFired { get; set; }
    }
    
    public class MyClass : IMyInterface<int>
    {
    	public MyHandler<int> EventFired { get; set;}
    }
    
    public void ConcreteHandler(IMyInterface<int> p)
    {
    	Console.WriteLine("I'm here");
    }
    
    void Main()
    {
    	var myValue = new MyClass();
    	var deleg = Delegate.CreateDelegate(typeof(MyHandler<int>), this, "ConcreteHandler");
    	myValue.GetType().GetProperty("EventFired").SetValue(myValue, deleg);
    	
    	// Test delegate invocation:
    	myValue.EventFired.Invoke(new MyClass());
    }
