    var entityType = dbContext.Model.FindEntityType(clrEntityType);
    
    // Table info 
    var tableName = entityType.Relational().TableName;
    var tableSchema = entityType.Relational().Schema;
    
    // Column info 
    foreach (var property in entityType.GetProperties())
    {
    	var columnName = property.Relational().ColumnName;
    	var columnType = property.Relational().ColumnType;
    };
