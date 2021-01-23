    TableName stub = new TableName();
    // One of these should be a primary key.
    stub.val1 = ...;
    stub.val2 = ...;
    TableName.Attach(stub); // Will throw an exception if the row with this primary key is already being tracked in memory.
