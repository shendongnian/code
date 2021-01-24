    private static void Main()
    {
        // This dictionary holds our lists
        // The 'key' represents the 'divisible by' number
        // The 'value' represents a list of all numbers that are divisible by the key
        var values = new Dictionary<int, List<int>>();
        // This list holds the ints that care about for finding 'divisible by' counts
        var divisibleByInts = new List<int> {11, 13};
        Random rnd = new Random();
        for (int i = 0; i < 1000; i++)
        {
            // Generate a random number
            var randomNumber = rnd.Next(1, 501);
            // Check if it's divisible by any of the ints we care about
            foreach (var divisibleByInt in divisibleByInts)
            {
                if (randomNumber%divisibleByInt == 0)
                {
                    // This random number is divisible by one of the numbers we care about, So add
                    // or update the appropriate list in the dictionary at that key with this value
                    if (values.ContainsKey(divisibleByInt))
                    {
                        values[divisibleByInt].Add(randomNumber);
                    }
                    else
                    {
                        values[divisibleByInt] = new List<int> {divisibleByInt};
                    }
                }
            }
        }
        Console.WriteLine("Here is a comparison of the list counts:");
        foreach (var divisibleByInt in divisibleByInts)
        {
            var countOfThisItem = (values.ContainsKey(divisibleByInt)) ? values[divisibleByInt].Count : 0;
            Console.WriteLine($"Numbers divisible by {divisibleByInt}: {countOfThisItem}");
        }
        Console.Write("\nDone!\nPress any key to quit.");
        Console.ReadKey();
    }
