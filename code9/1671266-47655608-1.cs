	var stopwatch = new Stopwatch();
	stopwatch.Start();
	Random rnd = new Random();
	//Generate 500 controls with random positions
	var controls = Enumerable.Range(0, 5000)
		.Select(index => new Control 
		{
			Top = rnd.Next(0, 1000), 
			Left = rnd.Next(0, 1000), 
			Width = rnd.Next(0, 1000), 
			Height = rnd.Next(0, 1000) 
		})
		.ToList();
	var controlsUnderMouse = controls
		.Where(c => c.Bounds.Contains(150, 150))
		.ToList();
	Console.WriteLine($"Found {controlsUnderMouse.Count()} controls in {stopwatch.Elapsed}");
