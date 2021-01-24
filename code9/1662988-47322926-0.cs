	public sealed class Bar : Map
	{
		public static Random _rand = new Random();
		public Bar(int index, string data, Func<string, string> mapper) : base(index, data, mapper)
		{
			if (_rand.Next(3) > 0)
			{
				BarId = Guid.NewGuid();
			}
		}
	}
