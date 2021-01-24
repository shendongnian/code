	public IObservable<X> Gather()
	{
		return Observable.Create<X>((Func<IObserver<X>, IDisposable>)GetXObserver);
	}
	
	private IDisposable GetXObserver(IObserver<X> observer)
	{
		return System.Reactive.Disposables.Disposable.Empty;
	}
