	private static object _gate = new object();
	private void ProcessQueue()
	{
		if (_workerThread == null || (_workerThread != null && _workerThread.IsAlive))
		{
			lock (_gate)
			{
				if (_workerThread == null || (_workerThread != null && _workerThread.IsAlive))
				{
					_workerThread = new ThreadStart(ProcessQueueInternal);
					_workerThread.Start();
				}
			}
		}
	}
