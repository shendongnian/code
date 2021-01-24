    DbConnection sourceConnection = // connection from the source
    DbConnection destinationConnection = // connection from the destination
    
    // Fill the DataTable using the sourceConnection
    dt = ...;
    
    // BulkInsert using the destinationConnection
    var bulk = new BulkOperation(destinationConnection);
    bulk.BulkInsert(dt);
