    using System.Linq;
    using System.IO;
    
    ...
    
    Dictionary<string, string> CodeToName = File
      .ReadLines("Test2.txt")
      .Select(line => line.Split(','))
      .GroupBy(items => items[0])
      .ToDictionary(chunk => chunk.Key, 
                    chunk => string.Join("; ", chunk.Select(item => item[1])));
