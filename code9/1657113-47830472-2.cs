          // 1. ShapeEntity is the custom .Net object that we want to write and read from Table Storage.
                ShapeEntity shapeEntity = new ShapeEntity(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "square", 4, 4);
        
                OperationContext operationContext = new OperationContext();
        // 2. Instantiate a TableEntityAdapter object, passing in the custom object to its constructor. Internally this instance will keep a reference to our custom ShapeEntity object. 
    
                TableEntityAdapter<ShapeEntity> writeToTableStorage = new TableEntityAdapter<ShapeEntity>(shapeEntity, partitionKey, rowKey);
    
    // 3. Now you can write the writeToTableStorage object to Table Storage just like any other object which inherits from ITableEntity interface. The TableAdapter generic class handles the boiler plate code and hand shaking between your custom .Net object and table storage sdk / service.
    
    To read your custom object from Table Storage:
    
    // 1. Read your entity back from table storage using the same partition / row key you specified (see step 2 above). You can use the Retrieve<T> table operation, specify T as TableEntityAdapter<ShapeEntity>
    
    // 2. This should return you the TableEntityAdapter<ShapeEntity> object that you wrote to TableStorage at step 3 above.
    
    // 3. To access the original ShapeEntity object, just refer to the OriginalEntity property of the returned TableEntityAdapter<ShapeEntity> object. 
    
