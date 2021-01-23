                var resolver = ServicePartitionResolver.GetDefault();
                var fabricClient = new FabricClient();
                var apps = fabricClient.QueryManager.GetApplicationListAsync().Result;
                foreach (var app in apps)
                {
                    Console.WriteLine($"Discovered application:'{app.ApplicationName}");
    
                    var services = fabricClient.QueryManager.GetServiceListAsync(app.ApplicationName).Result;
                    foreach (var service in services)
                    {
                        Console.WriteLine($"Discovered Service:'{service.ServiceName}");
    
                        var partitions = fabricClient.QueryManager.GetPartitionListAsync(service.ServiceName).Result;
                        foreach (var partition in partitions)
                        {
                            Console.WriteLine($"Discovered Service Partition:'{partition.PartitionInformation.Kind} {partition.PartitionInformation.Id}");
    
    
                            ServicePartitionKey key;
                            switch (partition.PartitionInformation.Kind)
                            {
                                case ServicePartitionKind.Singleton:
                                    key = ServicePartitionKey.Singleton;
                                    break;
                                case ServicePartitionKind.Int64Range:
                                    var longKey = (Int64RangePartitionInformation)partition.PartitionInformation;
                                    key = new ServicePartitionKey(longKey.LowKey);
                                    break;
                                case ServicePartitionKind.Named:
                                    var namedKey = (NamedPartitionInformation)partition.PartitionInformation;
                                    key = new ServicePartitionKey(namedKey.Name);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException("partition.PartitionInformation.Kind");
                            }
                            var resolved = resolver.ResolveAsync(service.ServiceName, key, CancellationToken.None).Result;
                            foreach (var endpoint in resolved.Endpoints)
                            {
                                Console.WriteLine($"Discovered Service Endpoint:'{endpoint.Address}");
                            }
                        }
                    }
