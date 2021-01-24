    Console.WriteLine("Type any number");
    string input = Console.ReadLine();
    int x;
    if (int.TryParse(input, out x))
    {
        //do your stuff here
    }
    else
    {
        Console.WriteLine("You didn't enter number");
    }
