	class MyActivity
	{
		private Subject<IObservable<string>> mainObl;
		private IDisposable subscription = null;
	
		public void OnCreate()
		{
			mainObl = new Subject<IObservable<string>>();
		}
	
		public void OnStart()
		{
			subscription = mainObl.Merge().Subscribe(x =>
			{
				Console.WriteLine(x);
			});
		}
	
		public void OnStop()
		{
			subscription.Dispose();
		}
	
		public void OnButtonClick()
		{
			var tmpObl = new [] { 1, 2, 3, 4 }
				.Select(x => x.ToString())
				.ToObservable();
			mainObl.OnNext(tmpObl);
		}
	}
