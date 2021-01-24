    static void GetItemsAndAddToCompartment(List<string> compartment, string compartmentName)
    {
        if (compartment == null) throw new ArgumentNullException(nameof(compartment));
        Console.WriteLine($"Enter items to add to {compartmentName} compartment below. Type 'done' when finished.");
        int counter = 1;
        while (true)
        {
            Console.Write($"Enter item #{counter++}: ");
            string item = Console.ReadLine();
            if (item.Equals("done", StringComparison.OrdinalIgnoreCase)) break;
            compartment.Add(item);
        }
    }
    static void DisplayCompartmentContents(List<string> compartment, string compartmentName)
    {
        Console.WriteLine($"{compartmentName} compartment contents");
        Console.WriteLine("-------------------------");
        if (compartment == null || !compartment.Any())
        {
            Console.WriteLine("[No items in this compartment]");
        }
        else
        {
            compartment.ForEach(Console.WriteLine);
        }
    }
