	var list = new List<int>();
    foreach (var number in  Enumerable.Range(1, 9))
	{
		list.Add(number);
	}
	
	Console.WriteLine(GetMiddle(list));
