    void Main()
    {
    	IsValid("ABC");   // false
    	IsValid("abc");   // true
    	IsValid("abc-."); // true
    }
    
    public static bool IsValid(string input)
    {
    	var regex = new Regex(@"[a-z-.]");
    	return regex.IsMatch(input);
    }
