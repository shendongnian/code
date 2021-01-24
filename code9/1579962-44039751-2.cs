	public static IObservable<IDisposable> ImagesInFolder(IScheduler scheduler)
	{
		return
			Observable
				.Range(0, 3)
				.ObserveOn(Scheduler.Default)
				.SelectMany(x =>
					Observable
						.Using(
							() => Disposable.Create(() => Console.WriteLine("Disposed!")),
							y => Observable.Return(y)))
			.Publish()
			.RefCount();
	}
