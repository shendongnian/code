	var input = new Subject<Price>();
	IObservable<IList<Price>> query =
		input
			.Publish(i =>
				Observable
					.Create<IList<Price>>(o =>
					{
						var timeBuffer =
							Observable
								.Timer(TimeSpan.FromSeconds(10.0))
								.Select(n => Unit.Default);
						var flush =
							i
								.Where(p => p.IS_IMPORTANT)
								.Select(n => Unit.Default);
						var sizeBuffer =
							i
								.Buffer(5)
								.Select(l => Unit.Default);
						return
							i
								.Window(() => Observable.Merge(timeBuffer, sizeBuffer, flush))
								.SelectMany(w => w.ToList())
								.Subscribe(o);
					}));
	query.Subscribe(w => DO_SOMETHING_WITH_PRICES(w));
