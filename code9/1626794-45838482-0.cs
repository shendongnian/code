	IObservable<ImmutableDictionary<string, Price>> sampled =
		Observable
			.Create<ImmutableDictionary<string, Price>>(o =>
			{
				var output = ImmutableDictionary<string, Price>.Empty;
				return
					source
						.Do(x => output = output.SetItem(x.Key, x))
						.Select(x => Observable.Interval(TimeSpan.FromSeconds(1.0)).Select(y => output).StartWith(output))
						.Switch()
						.Subscribe(o);
			});
