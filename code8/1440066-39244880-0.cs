	public static class Watcher
	{
		public static IWatcher<TKey> For<TKey>(IWatchable<TKey> target)
		{
			return new Watcher<IWatchable<TKey>, TKey>(target);
		}
	}
