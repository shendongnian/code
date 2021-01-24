    public static object ConvertByteArrayToValueType(Type type, byte [] bytearr) 
    {
    	if (type.IsValueType) // if you have a value type (BitConverter can handle only those)
    	{
    		// find the proper method based on the type name
    		MethodInfo mi = typeof(BitConverter).GetMethod("To" + type.Name, BindingFlags.Static | BindingFlags.Public);
    
    		if (mi != null)
    		{
    			return mi.Invoke(null, new object[] { bytearr, 0 }); // call the proper method
    		}
    	}	
    	return null;
    }
