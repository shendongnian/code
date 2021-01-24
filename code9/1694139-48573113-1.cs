	public class FifoMonitor
	{
		public class FifoCriticalSection : IDisposable
		{
			private readonly FifoMonitor _parent;
			
			public FifoCriticalSection(FifoMonitor parent)
			{
				_parent = parent;
				_parent.Enter();
			}
			
			public void Dispose()
			{
				_parent.Exit();
			}
		}
		
		
		private object _innerLock = new object();
		private volatile int counter = 0;
		private volatile int current = 1;
	
		public FifoCriticalSection Lock()
		{
			return new FifoCriticalSection(this);
		}
		
		private void Enter()
		{
			int mine = Interlocked.Increment(ref counter);
			Monitor.Enter(_innerLock);
			while (true)
			{
				if (current == mine )
				{
					return;
				}
				else
				{
					Monitor.Wait(_innerLock);
				}
			}
		}
	
		private void Exit()
		{
			Interlocked.Increment(ref current);
			Monitor.PulseAll(_innerLock);
			Monitor.Exit(_innerLock);
		}
	}
