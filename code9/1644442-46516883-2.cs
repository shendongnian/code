    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var s in Make3CharChunks(File.ReadAllText( /*your file path here*/ ""))
                Console.WriteLine(s);
    
            Console.ReadLine();
        }
    
        static IEnumerable<string> Make3CharChunks(string s)
                            => s.Aggregate(new List<string>(), (acc, c) =>
                    {
                        if (acc.Any() && acc.Last().Count() < 3)
                            acc[acc.Count - 1] = $"{acc.Last()}{c}";
                        else
                            acc.Add(c.ToString());
    
                        return acc;
                    });
    }
