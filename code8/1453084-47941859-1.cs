	public static class DeviceHelper
	{
		public static Task RunOnMainThreadAsync(Action action)
		{
			var tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(
				() =>
				{
					try
					{
						action();
						tcs.SetResult(null);
					}
					catch (Exception e)
					{
						tcs.SetException(e);
					}
				});
			return tcs.Task;
		}
		public static Task RunOnMainThreadAsync(Task action)
		{
			var tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(
				async () =>
				{
					try
					{
						await action;
						tcs.SetResult(null);
					}
					catch (Exception e)
					{
						tcs.SetException(e);
					}
				});
			return tcs.Task;
		}
	}
