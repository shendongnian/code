	var products = dalLayer.GetProductsList().Select(x => Tuple.Create(x.PId, x.Name));
	
	// before C# 7
	foreach(var p in products)
	{
		Console.WriteLine(p.Item1);
		Console.WriteLine(p.Item2);
	}
	
	
	// using C# 7
	
	/*foreach(var (PId, Name) in products)
	{
		Console.WriteLine(PId);
		Console.WriteLine(Name);
	}*/
