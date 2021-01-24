	public IObservable<StreamItem> LiveStream()
	{
	    _mySvc.Start();
	    return
			_mySvc
				.ThingChanged()
				.Materialize()
				.Do(x =>
				{
					if (x.Kind == NotificationKind.OnError)
					{
						OnError(x.Exception);
					}
				})
				.Dematerialize();
	}
