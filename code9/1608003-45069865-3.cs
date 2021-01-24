    while(true)
    {
        Console.Write("Enter a partial address: ");
        var partialAddress = Console.ReadLine();
        Console.WriteLine(new string ('-', 25 + partialAddress.Length));
        var normalizedAddress = GetNormalizedAddresses(partialAddress);
        if (!normalizedAddress.Any())
        {
            Console.WriteLine("Sorry, couldn't find anything.");
        }
        else
        {
            Console.WriteLine("That address normalizes to:");
            Console.WriteLine($" - {string.Join($"\n - ", normalizedAddress)}");
        }
        
        Console.WriteLine("\n");        
    }
