    public static class BackgroundWorkItemX
	{
		public static void QueueBackgroundWorkItem(Action<CancellationToken> workItem)
		{
			try
			{
				HostingEnvironment.QueueBackgroundWorkItem(workItem);
			}
			catch (InvalidOperationException)
			{
				workItem.Invoke(new CancellationToken());
			}
		}
	}
