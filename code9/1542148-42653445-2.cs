    static void Main()
    {
        List<double?> test = new List<double?>
        {
            null, null, 2, 3, 4, null, null, 3, 3, null
        };
        foreach (var sublist in FindNonNullRanges(test))
        {
            Console.WriteLine($"From {sublist.Start} to {sublist.End} = [{string.Join(", ", sublist.Numbers)}]");
        }
    }
