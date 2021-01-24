	private static async Task HTTPProcessQueue()
	{
		foreach (var queueItem in msgQueue.GetConsumingEnumerable())
		{
			if (queueItem != null)
			{
				if (!(await HTTPTransmitEmailItemAsync(queueItem.username, queueItem.filename)))
				{
				    await Task.Delay(5000);
				}
			}
		}
	}
