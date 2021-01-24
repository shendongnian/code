    //Add NuGet packages xunit, System.Reactive, FluentAssertions
	async void Main()
	{
		SetupObservable();
	
		var test2 = _jobQueue.Take(2)
			.Subscribe(x =>
			{
				CurrentJob.Status.ShouldBeEquivalentTo("OK");
				Console.WriteLine(CurrentJob.Status); //Ouptuts "OK" and "OK" as expected
			});
	}
	public IObservable<Unit> _jobQueue;
	public Logger _logger = new Logger();
	public IJob CurrentJob;
	
	// Define other methods and classes here
	public async void SetupObservable()
	{
		_jobQueue = Observable.Interval(TimeSpan.FromMilliseconds(500))
			.Select(_ => Observable.FromAsync(UpdateJob))
			.Concat()
			.Do(gotNewJob =>
			{
				if (gotNewJob)
					_logger.Information("some info");
			})
			.Where(gotNewJob => gotNewJob == true) // only accept new jobs.
			.Select(_ => Unit.Default)
			.Publish()
			.RefCount();
	}
	
	public async Task<bool> UpdateJob()
	{
		CurrentJob = new Job();
		CurrentJob.Status = "OK";
		return true;
	}
	
	public interface IJob {
		string Status { get; set;}
	}
	
	public class Job : IJob
	{
		public string Status { get; set;}
	}
	
	public class Logger
	{
		public void Information(string s) {}
	}
