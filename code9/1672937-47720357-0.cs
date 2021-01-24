    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
    	foreach (var prop in entity.GetProperties())
    	{
    		if (entity.IsOwned() && prop.IsPrimaryKey()) continue;
    		IEntityType propOwner = entity;
    		string propName = prop.Name, columnName = null;
    		do
    		{
    			if (!propMap.TryGetValue(propName, out var name))
    				name = AddUndercoresToSentence(propName, preserveAcronyms).ToLowerInvariant();
    			columnName = columnName == null ? name : name + "_" + columnName;
    			propName = propOwner.DefiningNavigationName;
    			propOwner = propOwner.DefiningEntityType;
    		}
    		while (propName != null);
    		prop.Relational().ColumnName = columnName;
    	}
    
    	if (entity.IsOwned()) continue;
    	var entName = entity.DisplayName();
    	if (!entMap.TryGetValue(entName, out var tableName))
    		tableName = AddUndercoresToSentence(entName, preserveAcronyms).ToLowerInvariant();
    	entity.Relational().TableName = tableName;
    }
