    static void Main(string[] args)
    {
        string fromTo = "M5000C001";
        IEnumerable<int> values = fromTo.Split('M', 'C')
                                        .Where(w => !string.IsNullOrWhiteSpace(w))
                                        .Select(int.Parse)
                                        .ToList();
        int from = values.First();
        int last = values.Last();
        Console.WriteLine("From" + from);
        Console.WriteLine("Last" + last);
    }
