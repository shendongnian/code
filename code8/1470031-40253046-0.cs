	static void Main(string[] args)
	{
		var list = new List<int> { 1, 2, 3, 4 };
		var enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			var listElement = enumerator.Current;
			Console.WriteLine(listElement + " ");
			list = list.Where(x => x != listElement).ToList();
		}
		enumerator.Dispose();
	
		Console.WriteLine("Count: " + list.Count);
	}
