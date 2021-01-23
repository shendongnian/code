    public static void Method(Type myType) 
    {
    	var thing = myType.GetInterfaces()
    		.Where(i => i.IsGenericType)
    		.Where(i => i.GetGenericTypeDefinition() == typeof(IList<>))
    		.FirstOrDefault()
    		.GetGenericArguments()[0];
    }
