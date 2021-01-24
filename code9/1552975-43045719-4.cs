	int min = 5;
	int max = 10;
	int[] array = new int[4];
	int count = 0;
	while(true)
	{
		int val;
		
        // read the input
		Console.WriteLine("enter btw 5 och 10");
        string input = Console.ReadLine();
        // parse it
		if(!int.TryParse(input, out val))
		{
		    Console.WriteLine("Not a valid number");
			continue;
		}
        // check the range
		if (val < min || val > max)
		{
			Console.WriteLine("wrong, enter btw 5 och 10");
			continue;
		}
        // store it.
		Console.WriteLine("Rätt siffra...");
		array[count] = val;
        // are we done?
        if(count== array.Length-1)
            // yes, break the while loop before we increase.
            break;
        // increase array index
		count++;
	}
	
	Console.WriteLine(count);
	Console.ReadKey();
