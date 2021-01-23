    public static bool ImplementsInterfaceOrBaseClass(this INamedTypeSymbol typeSymbol, Type typeToCheck)
    {
    	if (typeSymbol == null)
    	{
    		return false;
    	}
    
    	if (typeSymbol.MetadataName == typeToCheck.Name)
    	{
    		return true;
    	}
    
    	if (typeSymbol.BaseType.MetadataName == typeToCheck.Name)
    	{
    		return true;
    	}
    
    	foreach (var @interface in typeSymbol.AllInterfaces)
    	{
    		if (@interface.MetadataName == typeToCheck.Name)
    		{
    			return true;
    		}
    	}
    
    	return false;
    }
