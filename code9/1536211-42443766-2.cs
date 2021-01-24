    public class Result
    {
    	public List<int> Values {get;set;}
    	public int Max => Values.Max();
    	public Result()
    	{
    		Values = new List<int>();
    	}
    }
