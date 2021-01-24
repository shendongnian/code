    private void NotifyThreadPoolOfPendingWork()
	{
		ThreadPool.UnsafeQueueUserWorkItem(_ =>
		{
			// Note that the current thread is now processing work items.
			// This is necessary to enable inlining of tasks into this thread.
			_currentThreadIsProcessingItems = true;
			try
			{
				// Process all available items in the queue.
				while (true)
				{
					Task item;
					lock (_tasks)
					{
						// When there are no more items to be processed,
						// note that we're done processing, and get out.
						if (_tasks.Count == 0)
						{
							--_delegatesQueuedOrRunning;
							break;
						}
						// Get the next item from the queue
						item = _tasks.First.Value;
						_tasks.RemoveFirst();
					}
					// Execute the task we pulled out of the queue
					//base.TryExecuteTask(item);
					try
					{
						using (MemoryFailPoint memFailPoint = new MemoryFailPoint(650))
						{
							base.TryExecuteTask(item);
						}
					}
					catch (InsufficientMemoryException e)
					{
						Thread.Sleep(500);
						lock (_tasks)
						{
							_tasks.AddLast(item);
						}
					}
				}
			}
			// We're done processing items on the current thread
			finally { _currentThreadIsProcessingItems = false; }
		}, null);
	}
