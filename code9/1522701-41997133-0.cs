    static void Main(string[] args)
    {
        var list = new List<int>() { 0, 0, 1, 1, 1, 0, 0 };
        var result = list.Aggregate(new
                                    {
                                        Last = (int?)null,
                                        Counts = new Dictionary<int, int>(),
                                        Max = new Dictionary<int, int>()
                                    }, (context, current) =>
    
                                    {
                                        int count;
                                        if (!context.Counts.TryGetValue(current, out count))
                                            count = 1;
    
                                        if (context.Last == current)
                                            count += 1;
    
                                        int lastMax;
                                        context.Max.TryGetValue(current, out lastMax);
                                        context.Max[current] = Math.Max(lastMax, count);
    
                                        if (context.Last != current)
                                            count = 1;
    
    
                                        context.Counts[current] = count;
    
                                        return new { Last = (int?)current,  context.Counts, context.Max };
                                    });
    
        Console.WriteLine(string.Join(",", list) + "  Result: ");
        var output = string.Join(",  ", result.Max.Select(x => string.Format("{0} times {1}", x.Value, x.Key)));
        Console.WriteLine(output);
        Console.ReadKey();
    }
