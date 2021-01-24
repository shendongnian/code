    using(var client = new FabricClient())
    {
        var partitions = await client.QueryManager.GetPartitionListAsync(serviceName);
        foreach (var partition in partitions)
        {
            var partitionInformation = (NamedPartitionInformation)partition.PartitionInformation;
            var partitionKey = ServicePartitionKey(partitionInformation.Name);    
            IListen listenerClient = ServiceProxy.Create<IListen>(uri,partitionKey);
        }
    }
