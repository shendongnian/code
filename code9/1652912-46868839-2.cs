    static void Main()
    {
        Enumerable.Range(1, 100)
            .Select(num => 
                num % 3 == 0 
                    ? num % 7 == 0 ? "BlueSky": "Blue" 
                    : num % 7 == 0 ? "Sky" : num.ToString())
            .ToList()
            .ForEach(Console.WriteLine);
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
