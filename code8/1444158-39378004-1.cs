    public class Observable
    {
    	public readonly Dictionary<string, object> 
    		Properties = new Dictionary<string, object>();
    	
    	public object Get(string name)
    	{
    		object obj;
    		if (Properties.TryGetValue(name, out obj)){
    			return obj;
    		}
            // or do whatever you want when the given key doesn't exist.
            return null;
    	}
    }
