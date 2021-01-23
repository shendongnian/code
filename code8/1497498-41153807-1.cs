	var requestStream = Observable.FromEventPattern<UISearchBarTextChangedEventArgs>(ev => searchBar.TextChanged += ev,
							ev => searchBar.TextChanged -= ev)
		.Select(o => o.EventArgs.SearchText)
		.DistinctUntilChanged()
		.Throttle(TimeSpan.FromMilliseconds(300))
		.ObserveOn(SynchronizationContext.Current)
		.Select(t =>
		{
    #if DEBUG
            Console.WriteLine(t);
    #endif
		var instance = TranslateWebClient.Instance;//this is WebClient From where Get Request is made
		var data = instance.GetWordAsync(t);
			return data.ToObservable().ObserveOn(SynchronizationContext.Current);
		})
		.Publish()
		.RefCount();
	requestStream
		.SelectMany(o => Observable.Merge(
			Observable.Return(LoadState.RequestSent),
			Observable.Timer(TimeSpan.FromSeconds(1)).Select(_ => LoadState.ResponseLate),
			o.Select(_ => LoadState.ResponseReceived))
		)
		.Scan(LoadState.InitialState, 
			(previousState, newState) => previousState == LoadState.ResponseReceived && newState == LoadState.ResponseLate 
				? LoadState.ResponseReceived 
				: newState
		)
		.Subscribe(state =>
		{
			if(state == LoadState.ResponseLate)
				; //enable loading UI
			else
				; //disable loading UI
		});
		
	var dataStream = requestStream.Switch();
