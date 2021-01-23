    public static class DeviceHelper
	{
		public static Task RunOnMainThreadAsync(Action action)
		{
			var tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(
				() =>
				{
					action();
					tcs.SetResult(null);
				});
			return tcs.Task;
		}
		public static Task RunOnMainThreadAsync(Task action)
		{
			var tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(
				async() =>
				{
					await action;
					tcs.SetResult(null);
				});
			return tcs.Task;
		}
	}
