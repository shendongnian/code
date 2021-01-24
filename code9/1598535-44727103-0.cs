    var userInput = Console.ReadLine();
    int x;
    if(int.TryParse(userInput, out x))
    {
        Console.WriteLine("That's an int!");
    }
