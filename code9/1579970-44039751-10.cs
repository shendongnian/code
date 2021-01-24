	void Main()
	{
		ImagesInFolder(Scheduler.Default).Subscribe(x => { Thread.Sleep(1000); Console.WriteLine("A"); });
		ImagesInFolder(Scheduler.Default).Subscribe(x => { Thread.Sleep(3000); Console.WriteLine("B"); });
		ImagesInFolder(Scheduler.Default).Subscribe(x => { Thread.Sleep(2000); Console.WriteLine("C"); });
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
