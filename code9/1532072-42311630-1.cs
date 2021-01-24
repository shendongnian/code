	public class Record
	{
		public string Name;
		public List<string> Results;
		public double GetScore(Record benchmark)
		{
			var max = benchmark.Results.Count;
			var differences = benchmark.Results
				.Zip(this.Results, (a, b) => a == b)
				.Where(r => r == false)
				.Count();
			return ((double)max - differences) / max;
		}
	}
