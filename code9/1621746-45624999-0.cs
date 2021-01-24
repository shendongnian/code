	static void Main(string[] args)
	{
		while (true)
		{
			foreach (var y in RunQuery()) {
				Console.WriteLine($"{y.IsDigit}: {y.Count}");
			}
		}
	}
	class A{public bool IsDigit { get; set; } public int Count { get; set; } }
	private static IEnumerable<A> RunQuery()
	{
		return from c in Console.ReadLine()
					group c by char.IsDigit(c) into gr
					select new A { IsDigit = gr.Key, Count = gr.Count() };
	}
