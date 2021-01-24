	var merged = Observable.Merge(
		GetFromWeb().ToObservable(),
		GetFromDisk().ToObservable()
	);
	
	//Same thing using extension syntax
	var simply = GetFromWeb().ToObservable()
		.Merge(GetFromDisk().ToObservable());
		
