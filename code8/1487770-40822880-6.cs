       using System.Linq;
       ...
       // Tuple<int, int> - just a pair of two int values
       // a custom class to hold x, y values is a better design
       var Z = X
         .Zip(Y, (x, y) => new Tuple<int, int>(x, y))
         .OrderBy(item => item.Item1)  // let's sort by x
         .ThenBy(item => item.Item2)   // in case of tie by y
         .ToList();                    // or .ToArray()
