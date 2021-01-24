       using System.IO;
       using System.Linq;
       ......
       int[] array = File
         .ReadLines(file)
         .Select(line => line.Substring(line.IndexOf(':') + 1))
         .Where(line => !string.IsNullOrWhiteSpace(line))
         .Select(line => int.Parse(line))
         .ToArray();
