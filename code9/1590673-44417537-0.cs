    void Main()
    {
    	Dictionary<int, string> dict = new Dictionary<int, string>()
    	{
    		{ 1, "word1" },
    		{ 2, "word2" },
    		{ 3, "word3" },
    		{ 4, "word4" },
    		{ 5, "word5" },
    		{ 6, "word6" }
    	};
    	var randomizer = new Random();
    	GetRandomValue(dict, randomizer, new Range(4, 6), new Range(1,2)).Dump();
    }
    
    public TValue GetRandomValue<TValue>(IDictionary<int, TValue> dic, Random randomizer, params Range[] ranges)
    {
    	var range = ranges[randomizer.Next(0, ranges.Length)];
    	var key = randomizer.Next(range.From, range.To + 1);
    	return dic[key];
    }
    
    public class Range
    {
    	public Range(int @from, int to)
    	{
    		From = @from;
    		To = to;
    	}
    	public int From {get;set;}
    	public int To {get;set;}
    }
