    public static class TaskExtensions
	{
		public static Task<T> RunContinuationsAsynchronously<T>(this Task<T> task)
		{
			var tcs = new TaskCompletionSource<T>();
			task.ContinueWith((t, o) =>
			{
				if (t.IsFaulted)
				{
					if (t.Exception != null) tcs.SetException(t.Exception.InnerExceptions);
				}
				else if (t.IsCanceled)
				{
					tcs.SetCanceled();
				}
				else
				{
					tcs.SetResult(t.Result);
				}
			}, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			return tcs.Task;
		}
	}
