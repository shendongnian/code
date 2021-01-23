    public class Range
    {
    	public float MinValue { get; set; }
    	public float MaxValue { get; set; }
    }
    
    public static class FloatGenerator
    {
    	public static float GenerateFloatWithExclusionsInANaiveWay(int minValue, int maxValue, params Range[] rangeExclusions)
    	{
    		// We don't care about ranges outside of the min and max values allowed
    		var allowedRanges = rangeExclusions.Where(r => r.MinValue >= minValue && r.MaxValue <= maxValue);
    
    		// We use a guid to generate a random seed that random will use (reduces chance of duplicates)
    		var random = new Random(Guid.NewGuid().GetHashCode());
    
    		// We will use this to keep a pool of random values that fit within our expected ranges
    		var randomPool = new List<float>();
    
    		// Loop through each of the ranges and get a value that fits the range
    		foreach (var range in allowedRanges)
    		{
    			var randomValue = float.MaxValue;
    			while (randomValue < range.MinValue || randomValue > range.MaxValue)
    			{
    				randomValue = (random.Next((int)range.MinValue, (int)range.MaxValue) + (float)random.NextDouble());
    			}
    
    			randomPool.Add(randomValue);
    		}
    
    		// Return one of the acceptable random numbers randomly
    		return randomPool.ElementAt(random.Next(0, randomPool.Count - 1));
    	}
    }
