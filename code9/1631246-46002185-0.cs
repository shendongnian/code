	public static Task ForEachAsync<T>(this IEnumerable<T> source, int partitionCount, Func<T, Task> body, CancellationToken token = default(CancellationToken))
	{
		return Task.WhenAll(
			from partition in Partitioner.Create(source).GetPartitions(partitionCount)
			select Task.Run(async delegate
			{
				using (partition)
				{
					while (partition.MoveNext())
					{
						await body(partition.Current).ConfigureAwait(false);
					}
				}
			}, token) //token passed in
		);
	}
