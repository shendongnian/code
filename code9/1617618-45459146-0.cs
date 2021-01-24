    using System;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var start = @"C:\folder1\folder2\folder3";
            var end = @"folder3\folder4\file1.jpg";
    
            var startArray = start.Split('\\');
            var endArray = end.Split('\\');
    
            var final = Path.Combine(start, end);
            var endOfStart = startArray.LastOrDefault();
            if (endOfStart  == endArray.FirstOrDefault())
            {
                final = Path.Combine(start.Substring(0, start.Length - (endOfStart ?? "").Length), end);
            }
    
            Console.WriteLine(final);
            Console.ReadLine();
    
        }
    }
