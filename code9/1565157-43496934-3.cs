    List<string[]> listOfValues = new List<string[]>();
    using (var fs = File.OpenRead(@"C:\temp\csv.txt"))
    	using (var read = new StreamReader(fs))
    	{
    		while (!read.EndOfStream)
    		{
    			var line = read.ReadLine();
    			listOfValues.Add(line.Split(','));                    
    		}
    	}
