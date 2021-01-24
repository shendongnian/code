		public IDictionary<long, int> Get()
		{
			var applicationName = FabricRuntime.GetActivationContext().ApplicationName;
			var actorServiceName = $"{typeof(IManyfoldActorService).Name.Substring(1)}";
			var actorServiceUri = new Uri($"{applicationName}/{actorServiceName}");
			var fabricClient = new FabricClient();
			var partitions = new List<long>();
			var servicePartitionList = fabricClient.QueryManager.GetPartitionListAsync(actorServiceUri).GetAwaiter().GetResult();
			foreach (var servicePartition in servicePartitionList)
			{
				var partitionInformation = servicePartition.PartitionInformation as Int64RangePartitionInformation;
				partitions.Add(partitionInformation.LowKey);
			}
			var serviceProxyFactory = new ServiceProxyFactory();
			var actors = new Dictionary<long, int>();
			foreach (var partition in partitions)
			{
				var actorService = serviceProxyFactory.CreateServiceProxy<IManyfoldActorService>(actorServiceUri, new ServicePartitionKey(partition));
				var counts = actorService.GetCountsAsync(CancellationToken.None).GetAwaiter().GetResult();
				foreach (var count in counts)
				{
					actors.Add(count.Key, count.Value);
				}
			}
			return actors;
		}
