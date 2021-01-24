	protected sealed override void QueueTask(Task task)
	{
		// Add the task to the list of tasks to be processed.  If there aren't enough 
		// delegates currently queued or running to process tasks, schedule another. 
		lock (_tasks)
		{
			Console.WriteLine(_delegatesQueuedOrRunning);
			_tasks.AddLast(task);
			if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
			{
				++_delegatesQueuedOrRunning;
				NotifyThreadPoolOfPendingWork();
			}
		}
	}
