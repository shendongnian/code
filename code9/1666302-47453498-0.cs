	void Main()
	{
		var foo = new Foo();
		foo.Bars.Subscribe(x => Console.WriteLine(x));
		foo.OnBar(42);
	}
	
	public class Foo
	{
		public event EventHandler<double> Bar;
		
		public void OnBar(double value)
		{
			this.Bar?.Invoke(this, value);
		}
		
		public IObservable<double> Bars
		{
			get
			{
				return
					Observable
						.FromEventPattern<EventHandler<double>, double>(
							h => this.Bar += h,
							h => this.Bar -=h)
						.Select(x => x.EventArgs);
			}
		}	
	}
