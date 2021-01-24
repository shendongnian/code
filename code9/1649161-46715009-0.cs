    static void Main(string[] args)
    {
    	List<object> vals = new List<object> {1, 'c', "as", 2, 1};
    
    	foreach(var v in vals)
    		Console.WriteLine($"Is uniques: {IsUniq(v)}");
    
    	Console.ReadKey();
    }
    
    private static HashSet<object> _hashes = new HashSet<object>();
    private static bool IsUniq(object v)
    {
    	return _hashes.Add(v);
    }
