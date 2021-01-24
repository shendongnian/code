    using System.Linq;
    int top = ... some value    
    var first10Evens = Enumerable
       .Range(0, top)
       .Where(n => n % 2 == 0)
       .Take(10);
    
    foreach (var n in first10Evens)
       Console.WriteLine(n);
