     ...
     using System.Linq; 
     ...
     static void Main(string[] args) {
       var result = File
         .ReadLines(@"...", Encoding.UTF8)
         .SelectMany(line => line)               // string into characters
         .Where(c => char.IsLetterOrDigit(c))
         .GroupBy(c => c)
         .Select(chunk => new {
            Letter = chunk.Key,
            Count = chunk.Count() })
         .OrderByDescending(item => item.Count)
         .ThenBy(item => item.Letter)           // in case of tie sort by letter
         .Take(10)
         .Select(item => $"{item.Letter} freq. {item.Count}"); // $"..." - C# 6.0 syntax
       Console.Write(string.Join(Environment.NewLine, result));
     }
