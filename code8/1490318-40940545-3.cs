    // Update all columns
    ctx.BulkUpdate(list);
    // Update only IsActive column
    ctx.BulkUpdate(new List<Dll>(), operation => operation.ColumnInputExpression = dll => new { dll.Id, dll.IsActive});
    
    // Add new entities, update existing entities
    ctx.BulkMerge(list);
