       using System.Linq;
       ...
       float[][] tempsGrid = Enumerable
         .Range(0, 3)
         .Select(y => Enumerable
            .Range(0, 4)
            .Select(x => x + 10.0f * y)
            .ToArray())
         .ToArray();
    
       Console.Write(string.Join(Environment.NewLine, tempsGrid
         .Select(line => string.Join(", ", line)))); 
