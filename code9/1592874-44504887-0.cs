    public static async Task Run(MyType myEventHubMessage, Binder binder, TraceWriter log)
    {
        // ...
        var queueAttribute = new QueueAttribute(outputQueueName);
        var storageAttribute = new StorageAccountAttribute("MyAccount");
        var attributes = new Attribute[] { queueAttribute, storageAttribute };
        CloudQueue outputQueue = await binder.BindAsync<CloudQueue>(attributes);
        // ...
    }
