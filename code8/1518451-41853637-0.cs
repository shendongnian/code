    void Main()
    {
    	
    	Console.WriteLine(Replace());
    	
    }
    
    private static readonly string[] Keywords =
    {
      "SELECT", "FROM", "WHERE", 
      "GROUP", "HAVING", "ORDER", 
      "LEFT", "RIGHT", "JOIN", "INNER", 
      "OUTER", "ASC", "DESC", "AND", "OR","IN", 
      "BETWEEN", "BY", "NOT", "ON", "AS", "CASE", "WHEN", "ELSE"
    };
    
    static string Query = "Select * fRom TableA";
    
    static bool Exists(string word) =>
    	Keywords.Any(x => x.Equals(word, StringComparison.OrdinalIgnoreCase));
    
    
    static string Replace()
    {
    	var parts = Query.Split(' ');
    
    	var upperedParts = parts.Select(x => (Exists(x)) ? x.ToUpper() : x);
    
    	return String.Join(" ", upperedParts);
    
    }
