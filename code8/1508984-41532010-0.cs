    void Main()
    {
    	Console.WriteLine(Data().Select(t => t).Distinct().Skip(1).Any());
    }
    
    private Random __random = new Random();
    
    public IEnumerable<int> Data()
    {
    	while (true)
    	{
    		var @return = __random.Next(0, 10);
    		Console.WriteLine(@return);
    		yield return @return;
    	}
    }
