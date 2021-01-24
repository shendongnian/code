    var attributes = new Attribute[]
    {
        new StorageAccountAttribute("..."),
        new TableAttribute("...")
    };
    var output = await binder.BindAsync<IAsyncCollector<MyTableEntity>>(attributes);     
    await output.AddAsync(new MyTableEntity()
    {
        PartitionKey = "...",
        RowKey = "...",
        Minimum = ...,
        ...
    });
