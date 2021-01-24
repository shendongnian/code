	private static System.Collections.Concurrent.BlockingCollection<MsgType> msgQueue = new System.Collections.Concurrent.BlockingCollection<MsgType>();
	private static void AddQueueItems() // simulate adding items to the queue
	{
		msgQueue.Add(new MsgType());
		msgQueue.Add(new MsgType());
		msgQueue.Add(new MsgType());
		msgQueue.Add(new MsgType());
		// when adding is done, or the program is shutting down
		msgQueue.CompleteAdding();
	}
	private static void HTTPProcessQueue()
	{
		foreach (var queueItem in msgQueue.GetConsumingEnumerable())
		{
			if (queueItem != null)
			{
				if (!HTTPTransmitEmailItem(queueItem.username, queueItem.filename))
				{
					Thread.Sleep(5000);
				}
			}
		}
	}
