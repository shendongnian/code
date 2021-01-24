    void Main()
    {
    	var lines = new List<string> { "0\t4   5", "6\t9\t9" };
    	
    	lines.Select(l => GetPoint(l)).Dump();
    }
    
    static int[] GetPoint(string s)
    {
    	var values = s.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
    	
    	return values.Select(v => int.Parse(v)).ToArray();
    }
