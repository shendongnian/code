    public class MyCustomHelper
    {
    	// Can just be an empty class.
    }
    
    public static class MyCustomHelperExtensions
    {
    	public string GetStuff(this MyCustomHelper helper)
    	{
    		return "stuff";
    	}
    }
    
    public static class MyOtherCustomHelperExtensions
    {
    	public string GetOtherStuff(this MyCustomHelper helper)
    	{
    		return "other stuff";
    	}
    }
