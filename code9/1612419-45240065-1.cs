    //lines will be a string array
    var lines = File.ReadAllLines(@"C:\Text\TextFile.txt");
	for(int x = 0; x < lines .Length; x++)
	{
		var cols = lines [x].Split('.');
		for(int y = 0; y < cols.Length; x++)
		{
            //Here you have access to the value, and the x and y position
			Console.WriteLine("x: {0}, y: {1} value: {2}", x, y, cols[y]);
		}	
	}
