    private static void Number()
    {
        Console.Write("Type it in a number: ");
        int result;
	    bool parsedSuccessfully = int.TryParse(Console.ReadLine(), out result);
        
        if (parsedSuccessfully == false)
        {
            Console.WriteLine("Please type a number!");
        }
        else
        {
            Console.Write("Hi");
        }
        Console.ReadLine();
    }
