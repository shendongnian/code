    public static class FloatGenerator
    {
    	public static float GenerateFloat(int minValue, int maxValue, params float[] exclusions)
    	{
    		var random = new Random();
    		var decimalValue = (float)random.NextDouble();
    		var integerValue = random.Next(minValue, maxValue);
    		var randomFloat = (integerValue + decimalValue);
    
    		if (exclusions.Contains(randomFloat))
    		{
    			return GenerateFloat(exclusions);
    		}
    
    		return randomFloat;
    	}
    }
