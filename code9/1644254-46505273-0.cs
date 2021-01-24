	var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
	
	Func<int,bool> predicate = a => a%2==0;
	var odds = new List<int>();
	var evens = new List<int>();
	Action<List<int>, List<int>, Func<int, bool>> partition = (collection1, collection2, pred) =>
	{
		foreach (int element in collection)
		{
			if (pred(element))
			{
				collection1.Add(element);
			}
			else 
			{
				collection2.Add(element);
			}
		}
	};
	
	partition(evens, odds, predicate);
	odds.Dump();
	evens.Dump();
