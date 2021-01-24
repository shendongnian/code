    static void Main()
    {
        var usersRoot = Directory.GetParent(Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile));
        var minDate = usersRoot.CreationTime;
        foreach (var userFolder in usersRoot.GetDirectories())
        {
            if (userFolder.CreationTime < minDate) minDate = userFolder.CreationTime;
        }
            
        Console.WriteLine($"The first user folder was created on: {minDate}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
