	Random rnd = new Random();
	int x = 10;
	int y = 5;
	int count = x*y/3;
	var allPlaces =
                Enumerable.Range(0, count).Select(i => new {Text = "*", Order = rnd.Next() })
                    .Concat(Enumerable.Range(0, x*y - count)
                    .Select(i=>new { Text = ".", Order = rnd.Next() }))
                .OrderBy(i => i.Order).Select(i=>i.Text).ToList();
	for (var i = 0; i < x; x++)
	{
	    for (var j = 0; j < y; j++) { Console.Write(allPlaces[i*j + j]); } 
	    Console.WriteLine();
	}
