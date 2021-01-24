    static void TestArray(params object[] array)
    {  
        PrintValue(value);       
    }
    public void PrintValue(object value)
    {
    	var enumerable = value as IEnumerable;
    	if (enumerable != null)
    	{
    		foreach (var subvalue in enumerable)
    		{
    			PrintValue(subvalue);
    		}
    	}
    	else
    	{
    		Console.WriteLine(value.ToString());
    	}
    }
