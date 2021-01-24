    private static void Main(string[] args)
    {
        Console.WriteLine($"The command line arguments entered are: {string.Join(" ", args)}");
        if (args.Length > 0)
        {
            var filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The specified file was not found: {filePath}");
            }
            else
            {
                // Process the file here
                var fileBytes = File.ReadAllBytes(filePath);
            }
        }
        else
        {
            Console.WriteLine(
                "Error: Enter the full path to a file as the first command line argument");
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
