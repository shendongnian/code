	IObservable<char> sequence = Observable.Create<char>(o =>
	{
		string message = "hello world!";
		return Scheduler.Default.Schedule<string>(message, TimeSpan.FromMilliseconds(250.0), (state, schedule) =>
		{
			if (!String.IsNullOrEmpty(state))
			{
				o.OnNext(state[0]);
				schedule(state.Substring(1), TimeSpan.FromMilliseconds(250.0));
			}
			else
			{
				o.OnCompleted();
			}
		});
	});
