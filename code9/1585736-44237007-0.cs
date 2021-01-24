    string[] namen = new string[10];
    	
    	for(int i = 0;i<10;i++)
    	{
    		Console.WriteLine("Geef {0} naam in: ", i+1);
    		namen[i] = Console.ReadLine();;
    	}
    	namen
		   .GroupBy (n =>n)
		   .Where (w =>w.Count () > 1)
		   .ToList()
		   .ForEach(f=>Console.WriteLine(f.Key));
    	Console.ReadLine();
