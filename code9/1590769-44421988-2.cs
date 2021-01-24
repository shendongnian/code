    public static void DeepPrint(object obj, int recursionLevel)
    {
    	if(obj == null)
    	{
    		//print null
    		return;
    	}
    	var str = obj as string;
    	if(str != null)
    	{
    		//print str
    		return;
    	}
    	var enumer = obj as IEnumerable;
    	if(enumer != null)
    	{
    		while(enumer.MoveNext())
    		{
    			DeepPrint(enumer.Current, recursionLevel+1);
    		}
    		return;
    	}
        //print obj.ToString();
    }
