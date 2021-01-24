    public static bool IsSimpleType(this Type type)
    {
    	if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
    	{
    		// nullable type, check if the nested type is simple.
    		return type.GetGenericArguments()[0].IsSimpleType();
    	}
    	return type.IsPrimitive
    	  || type.IsEnum
    	  || type.Equals(typeof(string))
    	  || type.Equals(typeof(decimal));
    }
