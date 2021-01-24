    List<List<double>> items = new List<List<double>>();
		
	items.Add(new List<double>(){12.5,3.4,4.5,56.7,11.3,10.7});
	items.Add(new List<double>(){122.5,123.4,122.7,256.7,411.3,410.7});
		
	double itemToCheck = 1222.7;
		
	if(items.Any(x=>x.Contains(itemToCheck)))
	    Console.WriteLine("Item Found");
	else			
	    Console.WriteLine("Item Not Found");	
