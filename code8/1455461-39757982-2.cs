    public class Range
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
    }
    
    public static class FloatGenerator
    {
        public static float GenerateFloat(int minValue, int maxValue, params Range[] rangeExclusions)
        {
            var random = new Random();
            var decimalValue = (float)random.NextDouble();
            var integerValue = random.Next(minValue, maxValue - 1);
            var randomFloat = (integerValue + decimalValue);
            var excluded = false;
    
            foreach (var rangeExclusion in rangeExclusions)
            {
                if (randomFloat < rangeExclusion.MinValue || randomFloat > rangeExclusion.MaxValue)
                {
                    excluded = true;
                    break;
                }
            }
    
            if (excluded)
            {
                return GenerateFloat(minValue, maxValue, rangeExclusions);
            }
    
            return randomFloat;
        }
    }
