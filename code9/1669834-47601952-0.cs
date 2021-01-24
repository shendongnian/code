	[Service]
	public class BootService : Service
	{
		const string TAG = "SushiHangover";
		public const string SERVICE = "com.sushihangover.BootService";
		Thread serviceThread;
		public IBinder Binder { get; private set; }
		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Log.Debug(TAG, $"OnStartCommand : {Thread.CurrentThread.ManagedThreadId}");
			serviceThread = serviceThread ?? new Thread(ServiceRun); // Many ways... use a Task with a cancellation token, etc... 
			if (!serviceThread.IsAlive)
				try
				{
					serviceThread.Start();
				}
				catch (ThreadStateException ex) when (ex.Message == "Thread has already been started.")
				{
					// Xamarin.Android bug: isAlive always returns false, so eat the Start() exception if needed
				}
			base.OnStartCommand(intent, flags, startId);
			return StartCommandResult.Sticky;
		}
		public override void OnTrimMemory(TrimMemory level)
		{
			// Stop serviceThread? free resources? ...
			base.OnTrimMemory(level);
		}
		public override void OnLowMemory()
		{
			// Stop serviceThread? free resources? ...
			base.OnLowMemory();
		}
		public override void OnDestroy()
		{
			serviceThread.Abort(); // Handle ThreadAbortException in your thread, cleanup resources if needed...
			base.OnDestroy();
		}
		public override IBinder OnBind(Intent intent)
		{
			Log.Debug(TAG, $"OnBind");
			Binder = new BootBinder(this);
			return Binder;
		}
		public class BootBinder : Binder
		{
			public BootBinder(BootService service)
			{
				Service = service;
			}
			public BootService Service { get; private set; }
		}
		async void ServiceRun()
		{
			int i = 0;
			while (true) // Handle cancellations...
			{
				await Task.Delay(1000);
				Log.Debug(TAG, $"{i} : {Thread.CurrentThread.ManagedThreadId}");
				i++;
			}
		}
	}
