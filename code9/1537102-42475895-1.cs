    public class MyClass : IMyClass
    {
    	private readonly MyConfiguration _myConfiguration;
     
    	public MyClass(IOptions<MyConfiguration> myConfiguration)
    	{
    		_myConfiguration = myConfiguration.Value;
    	}
    }
