    public static class RandomExtensions
    {
        public static int NextWithinRange(this Random random, params Range[] ranges)
        {
            if (ranges.Length > 0)
            {
                Range range = ranges[random.Next(0, ranges.Length)];
                return random.Next(range.MinValue, range.MaxValue + 1);
            }
            
            return random.Next();
        }
        public class Range
        {
            public int MinValue { get; set; }
            public int MaxValue { get; set; }
            public Range(int minValue, int maxValue)
            {
                MinValue = minValue;
                MaxValue = maxValue;
            }
        }
    }
