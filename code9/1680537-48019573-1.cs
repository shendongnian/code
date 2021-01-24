    void Main()
    {
    	string pattern = @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}";
    	string input = @"My mail id is grk@gmail.com and my friend mail id is newxyz@yahoo.com";
    
    	var m = Regex.Match(input, pattern);
    	if (m.Success)
    	{
    		Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
    	}
    	m = m.NextMatch();
    	if (m.Success)
    	{
    		Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
    	}
    
    }
    
    // Define other methods and classes here
