    bool successfulParse = false;
    int change;
    do
    {
        Console.WriteLine("Enter change:");
        successfulParse = Int32.TryParse(Console.ReadLine(), out change);
    } while (!successfulParse);
    
    Console.WriteLine($"Change was {change} cents.");
