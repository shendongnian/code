    public static class ExtensionMethods
    {
    	public static T Find<T>(this T source, string id) where T : class, new()
    	{
    		return new T();
    	}
    }
    
    public class Child
    {
    	public void FindChild()
    	{
    		this.Find("");
    	}
    }
