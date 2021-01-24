    public interface IStartable
    {
    	void Start();
    }
    
    public class SomeClass : IStartable
    {
    	public void Start()
    	{
    		Console.WriteLine("Starting inside SomeClass");
    	}
    }
