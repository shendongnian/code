	var list = new List<int>();
    foreach (var number in  Enumerable.Range(1, 10))
	{
		list.Add(number);
	}
	
	Console.WriteLine(GetMiddle(list));
