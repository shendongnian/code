    using System.Linq;
    var sequence = Enumerable.Range(0, 10).Select(s => (uint)s).ToList();
    
    Console.WriteLine(sequence.Sum(s => (double)s));
    Console.WriteLine(sequence.Max());
    Console.WriteLine(sequence.Min());
