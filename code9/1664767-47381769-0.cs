    public static void Main()
    {
        Console.WriteLine("Using foreach");
        string userInput = "1";
        var logbook = new List<string[]> { new string[] { "1", "2" } };
        foreach (string[] logs in logbook)
        {
            if (logs[0] == userInput)
                Console.WriteLine("Word found!\n\nTitle: " + logs[0] + "\nText: " + logs[1] + "\n");
            else if (logs[1] == userInput)
                Console.WriteLine("Word found!\n\nTitle: " + logs[0] + "\nText: " + logs[1]);
        }
    }
