    var fabricClient = new FabricClient();
    var applicationList = fabricClient.QueryManager.GetApplicationListAsync().GetAwaiter().GetResult();
    foreach (var application in applicationList)
    {
        var serviceList = fabricClient.QueryManager.GetServiceListAsync(application.ApplicationName).GetAwaiter().GetResult();
        foreach (var service in serviceList)
        {
            var partitionListAsync = fabricClient.QueryManager.GetPartitionListAsync(service.ServiceName).GetAwaiter().GetResult();
            foreach (var partition in partitionListAsync)
            {
                var replicas = fabricClient.QueryManager.GetReplicaListAsync(partition.PartitionInformation.Id).GetAwaiter().GetResult();
                foreach (var replica in replicas)
                {
                    if (!string.IsNullOrWhiteSpace(replica.ReplicaAddress))
                    {
                        var replicaAddress = JObject.Parse(replica.ReplicaAddress);
                        foreach (var endpoint in replicaAddress["Endpoints"])
                        {
                            var endpointAddress = endpoint.First().Value<string>();
                            Console.WriteLine($"{service.ServiceName} {endpointAddress} {endpointAddress}");
                        }
                    }
                }
            }
        }
    }
