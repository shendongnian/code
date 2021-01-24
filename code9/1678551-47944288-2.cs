    static void DoWork()
    {
    	dynamic evens = GetEvens();
    	foreach (dynamic item in evens)
    		Console.WriteLine($"Position: {item.Position}, Number: {item.Num}");
    
    }
    
    static dynamic GetEvens() =>
    	new List<int> { 1, 2, 3, 4 }
    	.Where(x => x % 2 == 0)
    	.Select((x, index) => new { Position = index, Num = x });
