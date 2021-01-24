    void Main()
    {
    	var method = typeof(KeyValueConfigurationCollectionExtensions)
    		.GetMethods()
    		.Where(m => m.Name == "Get")
		    .Where(m => m.GetGenericArguments().Any())
    		.Single()
    		.Dump();
    	
    }
    
    // Define other methods and classes here
    public static class KeyValueConfigurationCollectionExtensions
    {
    	public static string Get(this KeyValueConfigurationCollection collection, string key)
    	{
    		return collection[key].Value;
    	}
    	public static T Get<T>(this KeyValueConfigurationCollection collection, string key)
    	{
    		return (T)Convert.ChangeType(collection[key].Value, typeof(T));
    	}
    }
    
    public class KeyValueConfigurationCollection
    {
    	public KeyValuePair<string, string> this [string key]
    	{
    		get
    		{
    			return new KeyValuePair<string, string>("KEY: " + key, "VALUE: Hi!");
    		}
    	}
    }
