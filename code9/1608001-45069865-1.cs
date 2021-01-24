    while(true)
    {
        Console.Write("\n\nEnter partial address: ");
        var partialAddress = Console.ReadLine();
        var normalizedAddress = GetNormalizedAddress(partialAddress);
        if (string.IsNullOrWhiteSpace(normalizedAddress))
        {
            Console.WriteLine("Sorry, couldn't find anything.");
        }
        else
        {
            Console.WriteLine("That address normalizes to:");
            Console.WriteLine($" - {normalizedAddress}");
        }                
    }
