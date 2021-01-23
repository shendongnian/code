    var bulk = new BulkOperation(connection)
    bulk.DestinationTableName = "dbo.Orders";
    
    bulk.ColumnMappings.Add("OrderId", ColumnMappingDirectionType.Output);
    bulk.ColumnMappings.Add("Price");
    bulk.ColumnMappings.Add("Quantity");
    
    bulk.BulkInsert(rows);
