    public static void Main(string[] args)
    {
        var tabSequence = new[] { 1, 2, 3, 7, 8, 9, 12, 15, 16, 17, 22, 23, 32 };
        var lastNr = int.MinValue;
        var missing = tabSequence.Aggregate(
            new List<IEnumerable<int>>(),
            (acc, nr) =>
            {
                if (lastNr == int.MinValue || lastNr == nr - 1)
                {
                    lastNr = nr; // first ever or in sequence
                    return acc;  // noting to do
                }
                acc.Add(Enumerable.Range(lastNr + 1, nr - lastNr - 1));
                return acc;
            }
        );
        Console.WriteLine(string.Join(", ", tabSequence));
        foreach (var inner in GetMissingSeq(tabSequence))
            Console.WriteLine(string.Join(", ", inner));
        Console.ReadLine();
    }
