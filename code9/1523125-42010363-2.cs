		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			Task.Run(() => SetupData());
			Console.WriteLine("UI Thread / Message Looper is not blocked");
		}
		void SetupData()
		{
			Task.Run(async () =>
			{
				Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper()?.Thread}");
				// Simulate a long running task
				await Task.Delay(TimeSpan.FromSeconds(10));
				Console.WriteLine("Done fetching/calculating data");
				RunOnUiThread(() =>
				{
					// Update the data fetched/calculated on the UI thread;
					Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper().Thread}");
				});
			}).Wait();
			Console.WriteLine("Done w/ SetupData");
		}
