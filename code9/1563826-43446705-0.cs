    using System.IO;
    using System.Linq;
    ...
    char[][] data = File
      .ReadLines(@"config.txt")
      .Select(line => line.ToCharArray())
      .ToArray();
