    // Easy to use
    context.BulkSaveChanges();
    
    // Easy to customize
    context.BulkSaveChanges(bulk => bulk.BatchSize = 100);
    
    // Perform Bulk Operations
    context.BulkDelete(endItems);
    context.BulkInsert(endItems);
    context.BulkUpdate(endItems);
    
    // Customize Primary Key
    context.BulkMerge(endItems, operation => {
       operation.ColumnPrimaryKeyExpression = 
            endItem => endItem.Code;
    });
