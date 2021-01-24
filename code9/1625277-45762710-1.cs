    class Properties
    {
    	private Dictionary<Type, int> values = new Dictionary<Type, int>();
    	Color? ColorSelection
    	{
    		get
    		{
    			return values.TryGetValue(typeof(Color), out int i)
    				? (Color?)i
    				: null;
    		}
    		set
    		{
    			values[typeof(Color)] = (int)value;
    		}
    	}
    	...
    }
