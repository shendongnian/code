    public static void Trigger([EventHubTrigger("{your-EventHub-name}")] EventData message)
    {
        string data = Encoding.UTF8.GetString(message.GetBytes());
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Message received. Data: '{data}'");
        Console.ResetColor();
    }
