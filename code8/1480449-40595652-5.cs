    static string GetTableName(Type entityType)
    {
    	return ComposeDbName(
    		GetModulePrefix(entityType),
    		CamelCaseToUnderscore(GetClassName(entityType)).ToUpper()
    	);
    }
    
    static string GetColumnName(Type entityType, string propertyName)
    {
    	return ComposeDbName(
    		GetModulePrefix(entityType),
    		GetTablePrefix(entityType),
    		propertyName == "Id" ? GetClassName(entityType) + "Id" : propertyName
    	);
    }
