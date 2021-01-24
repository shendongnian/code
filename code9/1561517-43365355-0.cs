    var list = new ReactiveList<int>();
    IReactiveDerivedList<int> dlist = null;
    dlist = list.CreateDerivedCollection(x => x, x =>
    {
    	var contains = dlist?.Contains(x) ?? false;
    	return !contains;
    });
    list.AddRange(new[] { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1 });
    Console.WriteLine(string.Join(", ", dlist.Select(x => x.ToString())));
    Console.ReadKey();
    // Outputs: 1, 2, 3, 4, 5, 6
