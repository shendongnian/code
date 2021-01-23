    private void ProcessAttributes(IEnumerable<Attribute> attributes)
    {
    	foreach (var attr in attributes)
    	{
    		if (attr is MyAttributeOne)
    		{
    			Console.WriteLine("MyAttributeOne found");
    		}
    		else if (attr is MyAttributeTwo)
    		{
    			Console.WriteLine("MyAttributeTwo found");
    		}
    		else
    		{
    		}
    	}
    }
