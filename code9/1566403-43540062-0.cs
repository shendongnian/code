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
    foreach(var type in typeof(SomeDto).GetInterfaces()) {
    	if(type.IsGenericType
    		&& type.GetGenericTypeDefinition() == typeof(ISome<>)
    		&& type.GetGenericArguments()[0] == typeof(Dto)) {
    		// success
    	}
    }
