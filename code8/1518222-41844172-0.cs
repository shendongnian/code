    public bool IsIt(object thing)
    {
    	var type = thing.GetType();
    	if (type.IsGenericType)
    	{
    		return type.GetGenericTypeDefinition() == typeof(MyThing<>);
    	} 
    	return false;
    }
