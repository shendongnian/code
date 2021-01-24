    private static void Main()
    {
        var resourceStr = "blah\\r\\n\\r\\nblah";
        Console.WriteLine("Original resource string:");
        Console.WriteLine(resourceStr);
        Console.WriteLine("\nAfter calling replace:");
        Console.WriteLine(resourceStr.Replace("\\r\\n", Environment.NewLine));
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
