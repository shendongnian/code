    public static bool InheritsMyView( Type type, out Type genericArgument )
    {
        foreach( var baseType in type.GetBaseTypes() )
        {
            if( !baseType.IsGenericType ) continue;
            if( baseType.GetGenericTypeDefinition() != typeof( MyView<> ) ) continue;
            genericArgument = baseType.GetGenericArguments()[0];
			return true;
        }
		
		genericArgument = null;
		return false;
    }
