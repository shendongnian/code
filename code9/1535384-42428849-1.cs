    var sequence = Enumerable.Range(0, 10000000).Select(s => (uint)s).AsParallel();
    
    Console.WriteLine(sequence.Sum(s => (double)s));
    Console.WriteLine(sequence.Max());
    Console.WriteLine(sequence.Min());
