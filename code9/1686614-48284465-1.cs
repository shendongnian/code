	var partialResponseObservable = input
		.Select(msg =>
		{
			switch(msg)
			{
				case PartialResponse r:
					return Notification.CreateOnNext(r);
				case ResponseComplete rc:
					return Notification.CreateOnCompleted<PartialResponse>();
				case ResponseError err:
					return Notification.CreateOnError<PartialResponse>(new Exception(err?.ToString()));
				default:
					throw new InvalidOperationException();
			}
		})
		.Dematerialize();
