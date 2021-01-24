    void Main()
    {
    	List<string> categories = new List<string>() { "cat1", "cat2", "cat3" };
    	List<string> tobeinserted = new List<string>() {"cat14", "cat2", "cat34"};
    	
    	for (int i = tobeinserted.Count-1; i >= 0 ; i--)
    	{
    		if (categories.Contains(tobeinserted[i]))
    		{
    			tobeinserted.RemoveAt(i);
    		}
    	}
    	
    	Console.WriteLine(string.Join(Environment.NewLine, tobeinserted));
    	
    }
