	public class QueuedBlockingCollection<T> : BlockingCollection<T>
	{
		private FifoMonitor monitor = new FifoMonitor();
	
		public QueuedBlockingCollection(int max) : base (max) {}
		
		public new void Add(T item)
		{
			using (monitor.Lock())
			{
				base.Add(item);
			}
		}
	}
	
