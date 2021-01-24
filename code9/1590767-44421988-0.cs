    public static void DeepPrint(object obj)
    {
    	if(obj == null)
    	{
    		//print null
    		return;
    	}
    	var enumer = obj as IEnumerable;
    	if(enumer != null)
    	{
    		while(enumer.MoveNext())
    		{
    			DeepPrint(enumer.Current);
    		}
    		return;
    	}
    	//print obj.ToString();
    }
