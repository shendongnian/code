    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out lowerRange))
    {
        // The user entered a valid integer you can use the lowerRange variable here
    }
    else
    {
        Console.WriteLine("Please enter a valid number");
    }
