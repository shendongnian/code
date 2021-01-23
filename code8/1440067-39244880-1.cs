	public class BeingWatched : IWatchable<int>
	{
		public BeingWatched(int key)
		{
			Key = key;
		}
		public int Key { get; }
	}
