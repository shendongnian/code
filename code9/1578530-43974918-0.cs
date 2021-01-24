     using System.Linq;
     ...
     int[][] data = File
       .ReadLines(@"C:\testing\result.txt")
       .Select(line => line
          .Split(new char[] {'\t'}, StringSplitOptions.RemoveEmptyEntries)
          .Select(item => int.Parse(item))
          .ToArray())
       .ToArray();  
