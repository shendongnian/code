    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var data = new List<double>() {32.00, 95.00, 60.00, 14.00, 62.00};
    
                var ordered = data.OrderByDescending(z => z);
                var oddGrouped = ordered.Select((value, index) =>
                    new {value, index}).Where(z => z.index % 2 == 0).Select(z => z.value);
                var evenGrouped = ordered.Select((value, index) =>
                    new { value, index }).Where(z => z.index % 2 == 1).Select(z => (int?)z.value)
                    .Concat(new List<int?>() { null}  ); // extra entry at the end in case there are an odd number of elements
    
                var result = oddGrouped.Zip(evenGrouped, (odd, even) => new Tuple<double, double?>(odd, even)).ToList();
    
                foreach (var entry in result)
                {
                    Console.WriteLine(entry);
                }
    
                Console.ReadLine();
            }
        }
    }
