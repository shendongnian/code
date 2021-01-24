	var subject = new Subject<Unit>();
	
	subject.Subscribe(u => Foo());
	subject.Subscribe(u => Bar());
	
	subject.OnNext(Unit.Default);
	subject.OnNext(Unit.Default);
