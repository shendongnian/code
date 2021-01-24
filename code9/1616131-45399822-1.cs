    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MoreLinq;
    
    class Program
    {
        private static IEnumerable<DecadeAndClosest> GroupByDecade(double[] input)
        {
            var rounded = input.Select(z => new
            {
                original = z,
                rounded = Math.Round(z / 10, MidpointRounding.AwayFromZero) * 10
            });
            var roundedWithDifference =
                rounded.Select(z => new { z.original, z.rounded, difference = Math.Abs(z.original - z.rounded) });
            var finalResults = roundedWithDifference.GroupBy(z => z.rounded)
                .Select(z => new DecadeAndClosest() { Decade = z.Key, Example = z.MinBy(Y => Y.difference).original });
            return finalResults;
        }
    
        public class DecadeAndClosest
        {
            public double Decade { get; set; }
            public double Example { get; set; }
        }
    
        static void Main(string[] args)
        {
            var input = new[]
            {
                10.15,
                14.45,
                19.65,
                22.18,
                27.89,
                30.15,
                31.15,
                37.46,
                42.01
            };
    
            var finalResults = GroupByDecade(input);
    
            foreach (var indiv in finalResults)
            {
                Console.WriteLine(string.Format("{0} - {1}", indiv.Decade, indiv.Example));
            }
    
            Console.ReadLine();
        }
    }
