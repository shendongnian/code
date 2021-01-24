    bool input;
    Console.WriteLine("Are you Major?");
    if (!bool.TryParse(Console.ReadLine(), out input))
    {
    	Console.WriteLine("No answer given");
    }
    else
    {
    	//....
    }
