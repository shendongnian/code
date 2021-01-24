	void Main()
	{
		ImagesInFolder(Scheduler.Default)
			.Publish(iif =>
				Observable
					.Merge(
						iif.Select(x => { Thread.Sleep(1000); Console.WriteLine("A"); return "A"; }),
						iif.Select(x => { Thread.Sleep(3000); Console.WriteLine("B"); return "B"; }),
						iif.Select(x => { Thread.Sleep(2000); Console.WriteLine("C"); return "C"; })))
			.Subscribe();
	}
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
							y => Observable.Return(y)));
	}
