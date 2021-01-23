    public class Observable
    {
    	public readonly Dictionary<string, object> 
    		Properties = new Dictionary<string, object>();
    	
    	public Property<T> Get<T>(string name)
    	{
    		object obj;
    		if (Properties.TryGetValue(name, out obj)){
    			try {
    			 	return (Property<T>) obj;
    			} catch(InvalidCastException){
                    // throw something which makes more sense to you
    				throw new ArgumentException("Could not cast the given object to the desired type");
    			}
    		}
            // throw something which makes more sense to you
    		throw new ArgumentException(name + " does not exist in the dictionary");
    	}
    }
