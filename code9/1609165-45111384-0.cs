    void Main()
    {
    	var sample = new Sample();
    	var odd = sample.Numbers(true);
    }
    class Sample
    {
    	public Func<bool, IEnumerable<int>> Numbers 
    	{ 
    		get => b => Enumerable.Range(1, 100).Select(x => b ? x * 2 : x * 2 - 1); 
    	}
    }
