    Console.WriteLine(Sum(new[] { 1, 2, 3 }));
    Console.WriteLine(Sum(new[] { 1, 2, 3, default(int?) }));
    Console.WriteLine(Sum(new[] { 1.1, 2.2, 3.3 }));
    Console.WriteLine(Sum(new[] { 1.1, 2.2, 3.3, default(double?) }));
    try { Console.WriteLine(Sum(new[] { 'a', 'b', 'c' })); }
    catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
