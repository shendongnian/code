    private static void PrintMap(int size = 20) {
      // initial empty map; I prefer using Linq for that, 
      // you can well rewrite it with good old for loops
      char[][] map = Enumerable.Range(0, size)
        .Select(i => Enumerable.Range(0, size)
           .Select(j => '#')
           .ToArray())
        .ToArray();
      // fill map with points; 
      // please, notice that we must not print points like (-1;3) or (4;100) 
      foreach (var point in s_Points)
        if (point.Item1 >= 0 && point.Item1 < map.Length &&
            point.Item2 >= 0 && point.Item2 < map[point.Item1].Length)
          map[point.Item1][point.Item2] = '*';
      // The string we want to output; 
      // once again, I prefer Linq solution, but for loop are nice as well
      string report = string.Join(Environment.NewLine, map
        .Select(line => string.Concat(line)));
      Console.Write(report);
    }
