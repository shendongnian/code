	public class Segment
	{
		public string Name { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
		public string Flight { get; set; }
	}
	public class Analyzer
	{
		public Analyzer(IEnumerable<Segment> segments)
		{
			Segments = segments;
		}
	
		protected IEnumerable<Segment> Segments { get; set; }
	
		public IEnumerable<IEnumerable<Segment>> Process(IEnumerable<Segment> origins = null, Stack<Segment> current = null)
		{
			if (origins == null)
				origins = Segments;
			if (current == null)
				current = new Stack<Segment>();
	
			foreach (var origin in origins)
			{
				current.Push(origin);
	
				var destinations = Segments.Where(p => p.Origin == origin.Destination);
				if (destinations.Any())
				{
					foreach (var child in Process(destinations, current))
					{
						yield return child;
					};
				}
				else
				{
					yield return current.Reverse().ToList();
				}
	
				current.Pop();
			}
		}
	}
