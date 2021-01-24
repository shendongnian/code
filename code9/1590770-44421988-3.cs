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
    		foreach(var e in enumer)
    		{
    			DeepPrint(e, recursionLevel+1);
    		}
    		return;
    	}
        //print obj.ToString();
    }
