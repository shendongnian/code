    public class RandomGenerator
    {
    	Dictionary<Tuple<double, double>, Tuple<int, int>> probability;
    	Random random;
    
    	public RandomGenerator(Dictionary<double, Tuple<int, int>> weights)
    	{
    		random = new Random();
    
    		Dictionary<double, Tuple<int, int>> percent = weights.Select(x => new { Key = x.Key / weights.Keys.Sum(), Value = x.Value }).ToDictionary(t => t.Key, t => t.Value);
    		probability = new Dictionary<Tuple<double, double>, Tuple<int, int>>();
    		double last = 0;
    		foreach (var item in percent.OrderBy(x => x.Key).Select(x => new { Key = x.Key, Value = x.Value }))
    		{
    			probability.Add(new Tuple<double, double>(last, last + item.Key), item.Value);
    			last += item.Key;
    		}
    	}
    
    	public double GetRandomNumber()
    	{
    		double w = random.NextDouble();
    
    		var range = probability.Where(x => w >= x.Key.Item1 && w <= x.Key.Item2).First().Value;
    
    		return random.Next(range.Item1, range.Item2);
    	}
    }
