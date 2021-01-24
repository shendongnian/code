    var number = new int[10];
    for (int i = 0; i < number.Length; i++)
    {
    	Console.Write("Write a number : ");
    	int x = int.Parse(Console.ReadLine());
    	if (number.Contains(x))
    	{
    		Console.WriteLine("This number already exists");
    		i--; // retry for this index
    	}
    	else
    	{
    		number[i] = x;
    	}
    }
