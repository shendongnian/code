    var bulk = new BulkOperation(connection)
    
    // Output Identity Value
    bulk.ColumnMappings.Add("CustomerID", ColumnMappingDirectionType.Output);
    
    // Map Column
    bulk.ColumnMappings.Add("Code");
    bulk.ColumnMappings.Add("Name");
    bulk.ColumnMappings.Add("Email");
    
    bulk.BulkInsert(dt);
