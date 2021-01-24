    private static void Main()
    {
        // Add any responses you want to allow to this list
        var validYesNoResponses = new List<string> { "y", "yes", "n", "no" };
        var openDoor = GetResponseFromUser("Do you want to open the door? (y/n): ",
            validYesNoResponses, StringComparison.OrdinalIgnoreCase);
        if (openDoor.StartsWith("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Ok, opening the door now!");
        }
        else
        {
            Console.WriteLine("Ok, leaving the door closed!");
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
