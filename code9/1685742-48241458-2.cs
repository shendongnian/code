    static void Main(string[] args)
    {
        var guid = new Guid("bdc39e63-5947-4704-9e12-ec66c8773742");
        Console.WriteLine(guid);
        var numbers = FindNumbersFromGuid(guid, 300, 5);
        
        Console.WriteLine("Numbers: ");
        foreach (var elem in numbers)
        {
            Console.WriteLine(elem);
        }
        Console.ReadKey();
    }
    private static int[] FindNumbersFromGuid(Guid input, 
        int maxNumber, int numberCount)
    {
        var seed = input.GetHashCode();
        var random = new Random(seed);
        return Enumerable.Range(0, numberCount)
            .Select(e => random.Next(0, maxNumber)).ToArray();
    }
