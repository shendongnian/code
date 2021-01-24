    class Dto
    {
    	// definition
    }
    
    interface ISome<T>
    {
    	// definition
    }
    
    class SomeDto: ISome<Dto>
    {
    	// definition	
    }
    
    ...
    var instance = new SomeDto();
    foreach(var type in instance.GetType().GetInterfaces()) {
    	if(type.IsGenericType
    		&& type.GetGenericTypeDefinition() == typeof(ISome<>)
    		&& type.GetGenericArguments()[0] == typeof(Dto)) {
    		// success
    	}
    }
