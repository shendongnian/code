    var entityType = dbContext.Model.FindEntityType(clrEntityType);
    
    // Table info 
    var tableName = entityType.GetTableName();
    var tableSchema = entityType.GetSchema();
    
    // Column info 
    foreach (var property in entityType.GetProperties())
    {
    	var columnName = property.GetColumnName();
    	var columnType = property.GetColumnType();
    };
