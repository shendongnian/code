    using System.Linq;
    
    public static void Main(string[] args)
    {
        var nums = Enumerable
            .Range(0, 50)
            .OrderBy(o => Guid.NewGuid().GetHashCode())  // poor mans shuffle
            .ToList(); 
        Console.WriteLine(string.Join(",", nums));
        Console.WriteLine(string.Join(",", nums.Take(15).OrderBy(i => i)));
        Console.WriteLine(string.Join(",", nums.OrderBy(i => i).Take(15)));
        Console.ReadLine();
    }
