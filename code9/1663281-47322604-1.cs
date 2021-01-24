	static readonly BlockingCollection<ItemToProcess> _queue = new BlockingCollection<ItemToProcess>(new ConcurrentQueue<ItemToProcess>());
	
	static void Main(string[] args)
	{
		IDisposable inserts =
			Observable
				.Interval(TimeSpan.FromSeconds(5.0))
				.Subscribe(_ =>
				{
					_queue.Add(new ItemToProcess() { Value = "value" });
				});
	
		IDisposable checks =
			new CompositeDisposable(
				Disposable.Create(() => _queue.CompleteAdding()),
				_queue
					.GetConsumingEnumerable()
					.ToObservable(Scheduler.Default)
					.Subscribe(item =>
					{
						Console.WriteLine(item.Value);
					}));
	}
