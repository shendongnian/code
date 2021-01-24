     using System.Linq;
     ...
     int[][] data = File
       .ReadLines(@"C:\testing\result.txt")
       .Select(line => line
           // Uncomment this if you have empty lines to filter out:
           // .Where(line => !string.IsNullOrWhiteSpace(line)) 
          .Split(new char[] {'\t'}, StringSplitOptions.RemoveEmptyEntries)
          .Select(item => int.Parse(item))
          .ToArray())
       .ToArray();  
