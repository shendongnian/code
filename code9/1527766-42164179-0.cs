	var a = new Subject<Unit>();
	var b = new Subject<Unit>();
	var observable = a.DiscriminatedUnion(b)
		.Scan(new State(0, 1), (state, du) => du.Unify(
			/* A clicked case */_ => new State(state.A + state.B, state.B), 
			/* B clicked case */_ => new State(state.A, state.A)
		)
	);
	observable.Subscribe(state => Console.WriteLine($"a = {state.A}, b = {state.B}"));
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	b.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	a.OnNext(Unit.Default);
	b.OnNext(Unit.Default);
