	var _updates = new Subject<Unit>();
	var result = Observable.Merge(
		_updates.Materialize(),
		Observable.Empty<Unit>()
		   .Delay(TimeSpan.FromSeconds(5))
		   .Materialize()
	   )
	   .Take(1)
	   .Wait();
	   
	switch (result.Kind)
	{
		case NotificationKind.OnCompleted:
			//time's up, or someone called _updates.OnCompleted().
			break;
		case NotificationKind.OnNext:
			var message = result.Value;
			//Message received. Handle message
			break;
		case NotificationKind.OnError:
			var exception = result.Exception;
			//Exception thrown. Handle exception
			break;
	}
