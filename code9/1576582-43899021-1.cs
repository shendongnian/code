    static void GetItemsAndAddToCompartment(List<string> compartment, string compartmentName)
    {
        if (compartment == null) throw new ArgumentNullException(nameof(compartment));
        Console.WriteLine($"Enter items to add to {compartmentName} compartment below.Type 'done' when finished.");
        int counter = 1;
        while (true)
        {
            Console.Write($"Enter item #{counter++}: ");
            string item = Console.ReadLine();
            if (item.Equals("done", StringComparison.OrdinalIgnoreCase)) break;
            compartment.Add(item);
        }
    }
    static void DisplayBagContents(List<string> mainCompartment, List<string> outerCompartment)
    {
        Console.WriteLine("Main compartment contents");
        Console.WriteLine("-------------------------");
        if (mainCompartment == null || !mainCompartment.Any())
        {
            Console.WriteLine("[No items in this compartment]");
        }
        else
        {
            mainCompartment.ForEach(Console.WriteLine);
        }
        Console.WriteLine("Outer compartment contents");
        Console.WriteLine("-------------------------");
        if (outerCompartment == null || !outerCompartment.Any())
        {
            Console.WriteLine("[No items in this compartment]");
        }
        else
        {
            outerCompartment.ForEach(Console.WriteLine);
        }
    }
