    // Easy to use
    var bulk = new BulkOperation(connection);
    bulk.BulkInsert(dt);
    bulk.BulkUpdate(dt);
    bulk.BulkDelete(dt);
    bulk.BulkMerge(dt);
    
    // Easy to customize
    var bulk = new BulkOperation<Customer>(connection);
    bulk.BatchSize = 1000;
    bulk.ColumnInputExpression = c => new { c.Name,  c.FirstName };
    bulk.ColumnOutputExpression = c => c.CustomerID;
    bulk.ColumnPrimaryKeyExpression = c => c.Code;
    bulk.BulkMerge(customers);
