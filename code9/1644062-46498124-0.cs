    static void Main()
    {
        var minDate = DateTime.MaxValue;
        var usersRoot = Directory.GetParent(Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile));
        foreach (var userFolder in usersRoot.GetDirectories())
        {
            if (userFolder.CreationTime < minDate) minDate = userFolder.creationDate;
        }
            
        Console.WriteLine($"The first user folder was created on: {minDate}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
