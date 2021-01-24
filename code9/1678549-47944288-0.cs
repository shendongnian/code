    dynamic even = new List<int> { 1, 2, 3, 4 }
    			  .Where(x => x % 2 == 0)
    			  .Select((x, index) => new { Position = index, Num = x });
    // Output:
    // Position: 0, Number: 2
    // Position: 1, Number: 4
    foreach (dynamic item in even)
    {
    	Console.WriteLine($"Position: {item.Position}, Number: {item.Num}");
    }
