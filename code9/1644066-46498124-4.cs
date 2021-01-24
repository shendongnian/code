    static void Main()
    {
        // This will hold the oldest date, so start it at MaxValue
        var oldestDate = DateTime.MaxValue;
        // Loop through each defined special folder
        foreach (Environment.SpecialFolder specialFolder in 
            Enum.GetValues(typeof(Environment.SpecialFolder)))
        {
            // Get the path to this folder
            var folderPath = Environment.GetFolderPath(specialFolder);
            // Some special folders may not exist, so verify the path first
            if (Directory.Exists(folderPath))
            {
                // If the created date of this folder is older, update our variable
                var createDate = Directory.GetCreationTime(folderPath);
                if (createDate < oldestDate) oldestDate = createDate;
            }
        }
        Console.WriteLine($"The oldest speical folder was created on: {oldestDate}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
