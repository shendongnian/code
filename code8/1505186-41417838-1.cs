    var doWorkBegins = changed
        .Select(x => DateTime.Now)
        .Throttle(TimeSpan.FromSeconds(5));
    var doWorkEnds = doWorkBegins
        .SelectMany(x => 
        {
            Log.Info("Start work...");
            // DoWork();
            //
			// should return an observable that returns a single value when complete.
			// If DoWork is just a void, then can use 
			// return Observable.Return(Unit.Default);
        });
		
    var lists = changed
		.Buffer(() => doWorkEnds)
		.Publish().RefCount();
		
	var succeeded = lists
		.Where(l => l.Count == 0);
		
	var invalidate = lists
		.Where(l => l.Count > 0);
	invalidate.Subscribe(x =>
    {
            Log.Info("There were changes while we worked... Invalidating");
            Invalidate();
    }, cancellationToken);
	
	succeeded.Subscribe(x => 
	{
		Log.Info("Succeeded");
	}, cancellationToken);
