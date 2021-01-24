	var subject = new Subject<Unit>();
	var query = subject.ObserveOn(Scheduler.Default).Publish();
	
	query.Subscribe(u => Foo());
	query.Subscribe(u => Bar());
	
	query.Connect();
	
	subject.OnNext(Unit.Default);
	subject.OnNext(Unit.Default);
