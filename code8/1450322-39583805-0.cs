	public class ConcurrentLoop
	{
		private static Subject<MyJob> _jobs = new Subject<MyJob>();
		
		private static IDisposable _subscription =
			_jobs
				.Synchronize()
				.ObserveOn(Scheduler.Default)
				.Subscribe(job =>
				{
					//Do something
				});
	
		public static void QueueJob(MyJob job)
		{
			_jobs.OnNext(job);
		}
	}
