    using System;
    using System.Linq;
    using MoreLinq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "While Kim kept kicking I ate my Dunkin donut with great gusto";
    
                var value = input.Split(' ');
    
                var lagged = value.Lag(1, (current, previous) => new { current = current?.ToLowerInvariant(), previous = previous?.ToLowerInvariant() });
                var leaded = value.Lead(1, (current, next) => new { next = next?.ToLowerInvariant() });
    
                var results = lagged.Zip(leaded, (x, y) => x.current?.FirstOrDefault() == x.previous?.FirstOrDefault() ||
                                                           x.current?.FirstOrDefault() == y.next?.FirstOrDefault());
    
                Console.WriteLine(string.Join(",", results));
                Console.ReadLine();
            }
        }
    }
