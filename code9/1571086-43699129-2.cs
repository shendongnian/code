    using System.IO;
    using System.Linq;
    ...
    string path = @"C:\MyFile1.txt";
    int[] result = File
      .ReadLines(path)
      .Select(line => int.Parse(line))
      .ToArray(); 
