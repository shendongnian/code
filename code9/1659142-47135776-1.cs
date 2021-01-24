	public static void ExecuteEvents()
	{
		foreach (EventData data in blockingCollection.GetConsumingEnumerable())
		{
			var local = data;
			switch (local.EventType)
			{
				case EventType1:
					ThreadPool.QueueUserWorkItem(o =>
					{
						Function1(local);
					});
					break;
				case EventType2:
					ThreadPool.QueueUserWorkItem(o =>
					{
						Function2(local);
					});
				default:
					break;
			}
		}
	}
