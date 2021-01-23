    void Test(Type type)
    {
    	if (type.DeclaringType.IsGenericType)
    		Console.WriteLine("1");	
    	else 
    		Console.WriteLine("2");
    }
