    var entityType = db.Model.FindEntityType(typeof(BaseEntity));
    
    // Table info 
    var tableName = entityType.GetTableName();
    var tableSchema = entityType.GetSchema() ?? entityType.GetDefaultSchema();
    
    // Column info 
    foreach (var property in entityType.GetProperties())
    {
    	var columnName = property.GetColumnName();
    	var columnType = property.GetColumnType();
    };
