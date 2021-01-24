	var input = new Subject<Price>();
	IObservable<IList<Price>> query =
		input
			.Publish(i =>
				Observable
					.Create<IList<Price>>(o =>
					{
						var flush = new Subject<Unit>();
						var timeBuffer =
							Observable
								.Timer(TimeSpan.FromSeconds(10.0))
								.Select(n => Unit.Default);
						var sizeBuffer =
							i
								.Buffer(5)
								.Select(l => Unit.Default);
						var subscription1 =
							i
								.Window(() => Observable.Merge(timeBuffer, sizeBuffer, flush))
								.SelectMany(w => w.ToList())
								.Subscribe(o);
						var subscription2 =
							i
								.Where(p => p.IS_IMPORTANT)
								.Subscribe(p => flush.OnNext(Unit.Default));
						return new CompositeDisposable(subscription1, subscription2);
					}));
	query.Subscribe(w => DO_SOMETHING_WITH_PRICES(w));
