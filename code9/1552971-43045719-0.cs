	int min = 5;
	int max = 10;
	int[] array = new int[4];
	int index = 0;
	while(true)
	{
		Console.WriteLine("enter btw 5 och 10");
		int val = int.Parse(Console.ReadLine());
		if (val >= min && val <= max)
		{
			Console.WriteLine("Rätt siffra...");
			array[index] = val;
			
			if(index == array.Length-1)
			    break;
				
			index++;
		}
		else
		{
			Console.WriteLine("wrong, enter btw 5 och 10");
		}
	}
	Console.WriteLine(index);
	Console.ReadKey();
