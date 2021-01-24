	// I made a guess that context is of type DbContext
	public UpsertEntities<T>(IList<T> entities, Action<DbContext, T> upsert) where T : class {
		int totalImported = 0;
		int totalRecords = entities.Count();
		var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };
		var exceptions = new ConcurrentQueue<Exception>();
		var errors = new ConcurrentBag<string>();
		var batches = entities.ChunkBy(100);
		foreach (var batch in batches)
		{
			var loopResult = Parallel.ForEach(batch, options, e =>
			{
				try
				{
					using (var context = GetContext())
					{
						// call to action parameter
						upsert(context, e);
					}
					Interlocked.Increment(ref totalImported);
				}
				catch (Exception exception)
				{
					exceptions.Enqueue(exception);
					errors.Add("Error Import " + e.Id + " " + exception.Message);
				}
				if (totalImported % 1000 == 0)
					LoggingEngine.Instance.Info(Thread.CurrentThread.ManagedThreadId + " - " + " Imported " + totalImported + " of " + totalRecords + " records ");
			});
		}
		foreach (var err in errors)
			LoggingEngine.Instance.Error(err);
	 }
