	void Main()
	{
		var msc = new MySecondClass();
	
		msc.Changes.Subscribe(ep =>
		{
			/* Do stuff with
				ep.Sender
				ep.EventArgs
					from the `MyFirstClass` instances
			*/
		});
	}
	
	public class MyFirstClass
	{
		public event EventHandler ChangesHappened;
		public IObservable<EventPattern<EventArgs>> Changes;
	
		public MyFirstClass()
		{
			this.Changes = Observable.FromEventPattern<EventHandler, EventArgs>(
				h => this.ChangesHappened += h, h => this.ChangesHappened += h);
		}
	
		public void MyMethod()
		{
			ChangesHappened?.Invoke(this, new EventArgs());
		}
	}
	
	public class MySecondClass
	{
		public IObservable<EventPattern<EventArgs>> Changes;
	
		private List<MyFirstClass> first = new List<MyFirstClass>();
	
		public MySecondClass()
		{
			this.Changes = first.Select(f => f.Changes).Merge();
		}
	}
