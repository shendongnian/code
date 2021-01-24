    static void Main(string[] args)
    {
        var clientInput = "14:57";
        var startTime = TimeSpan.Parse(clientInput);
        var currentTime = DateTime.Now.TimeOfDay;  // "06:41:52.2451249"
        if (startTime <= currentTime)
        {
            Console.WriteLine("We should have started {0} minutes ago!", 
                (int)currentTime.Subtract(startTime).TotalMinutes);
        }
        else
        {
            Console.WriteLine("We will start in: {0} minutes.", 
                (int)startTime.Subtract(currentTime).TotalMinutes);
        }
            
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
