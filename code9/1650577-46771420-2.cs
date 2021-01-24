    using System.Linq;
    ...
    // Let user input all the items in one go, e.g.
    // Car, Truck, Motorbike, Cat, Dog, Bird
    string[] source = Console
      .ReadLine()
      .Split(new char[] { ' ', '\t', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
    // size of the line; 
    // simplest approach (Parse); int.TryParse is a better choice
    int n = int.Parse(Console.ReadLine());
    // Let's create a jagged array with a help of modulo arithmetics:
    //   source.Length / n + (source.Length % n == 0 ? 0 : 1) 
    // we have "source.Length / n" complete lines and (possible) incomplete tail
    string[][] result = Enumerable
      .Range(0, source.Length / n + (source.Length % n == 0 ? 0 : 1))
      .Select(index => source
         .Skip(n * index) // skip index lines (each n items long)
         .Take(n)         // take up to n items
         .ToArray())      // materialize as array 
      .ToArray();
    // finally, let's join the jagged array (line by line) into a single string
    string text = "[" + string.Join(" ", result
      .Select(line => $"[{string.Join(", ", line)}]")) + "]";
    Console.WriteLine(text);
