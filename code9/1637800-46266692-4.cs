	public static class ObservableExtensions
	{
		public static IObservable<T> Process<T>(
			this IObservable<T> source,
			Action<T> preprocess,
			Action<T> postprocess)
		{
			return Observable.Create<T>(o =>
				source.Do(preprocess).Subscribe(x =>
				{
					o.OnNext(x);
					try
					{
						postprocess(x);
					}
					catch (Exception e)
					{
						o.OnError(e);
					}
				},
				o.OnError,
				o.OnCompleted)
			);
		}
	}
