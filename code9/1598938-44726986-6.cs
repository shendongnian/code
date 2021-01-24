    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    public class Program
    {
        private readonly List<string> list;
        
        public Program()
        {
            list = Enumerable.Range(0, 100000)
                .Select(_ => GenerateValue())
                .ToList();
        }
        
        // Just to test the impact of copying...
        [Benchmark]
        public List<string> NoSorting()
        {
            var copy = new List<string>(list);
            return copy;
        }
    
        [Benchmark]
        public List<string> NoParsing()
        {
            var copy = new List<string>(list);
            copy.Sort(NumericComparer.Instance);
            return copy;
        }
        
        [Benchmark]
        public List<string> WithParsing() => list.OrderBy(x => long.Parse(x)).ToList();
        
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
        
        [Benchmark]
        public List<string> WithPadding()
        {
            int maxLength = list.Max(y => y.Length);
            return list.OrderBy(x => x.PadLeft(maxLength, '0')).ToList();
        }        
    
        // Use the same seed on all tests
        static readonly Random random = new Random(1);
        static string GenerateValue()
        {
            // Up to 11 digits...
            long leading = random.Next(100000);
            long trailing = random.Next(1000000);
            long value = leading * 1000000 + trailing;
            // Pad to 9, 10 or 11 randomly
            int width = random.Next(3) + 9;
            return value.ToString().PadLeft(width, '0');
        }
    }
    // NumericComparer as per post
