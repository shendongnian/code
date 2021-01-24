	class ReactiveTesting
	{
		public IObservable<SomeEvents> AllEvents { get; }
		public ReactiveTesting(IObservable<IObservable<SomeEvents>> eventSource)
		{
			AllEvents = eventSource.Merge().Publish().RefCount();
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			var someTypeWithObservable = new SomeTypeWithObservable();
			var reactiveTesting = new ReactiveTesting(Observable.Return(someTypeWithObservable.SomeObservableEvents));
			reactiveTesting.AllEvents.Subscribe(next => Console.WriteLine(string.Format("Subscriber 1 - {0}", next.ToString("G"))));
			reactiveTesting.AllEvents.Subscribe(next => Console.WriteLine(string.Format("Subscriber 2 - {0}", next.ToString("G"))));
			someTypeWithObservable.TriggerEvent();
			someTypeWithObservable.TriggerEvent();
			someTypeWithObservable.TriggerEvent();
	
			Console.WriteLine("Press key...");
			Console.ReadLine();
	
		}
	}
	
