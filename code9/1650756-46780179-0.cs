	public class Revertable<T>
	{
		public readonly T DefaultValue;
		public readonly TimeSpan ResetDelay;
		private T _currentValue;
		private DateTimeOffset _resetTime;
        public Revertable(T defaultValue, TimeSpan resetDelay)
		{
			this.DefaultValue = defaultValue;
			this.ResetDelay = resetDelay;
            _currentValue = defaultValue;
			_resetTime = DateTimeOffset.MinValue;
		}
		
		public T Value 
		{ 
			get
			{
				return (System.DateTimeOffset.Now > _resetTime)
					? DefaultValue 
					: _currentValue;
			}
			set
			{
				_currentValue = value;
				_resetTime = System.DateTimeOffset.Now.Add(this.ResetDelay); 
			}
		}
	}
	
	public static void Main()
	{
		var r = new Revertable<string>("Default value", new TimeSpan(0,0,1));
		Console.WriteLine("Value is now {0}", r.Value);
		r.Value = "Changed";
		for (int i = 0; i<30; i++)
		{
			System.Threading.Thread.Sleep(100);
			Console.WriteLine("Value is now {0}", r.Value);
		}
	}
