    private IObservable<Unit> StartAsync(Action unsubscribe)
    {
        return
			Observable
				.Create<Unit>(o =>
				{
					var subscription =
						Observable
							.Timer(TimeSpan.FromSeconds(1))
							.Select(_=> Unit.Default)
							.Subscribe(o);
					return new CompositeDisposable(
						subscription,
						Disposable.Create(unsubscribe));
				});;
    }
