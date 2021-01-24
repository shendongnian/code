	public class QueueThing
	{
		private List<QueueItem> _cantTouchThis;
		
		public IReadOnlyCollection<QueueItem> GetQueue()
		{
			return _cantTouchThis.AsReadOnly();
		}
	}
