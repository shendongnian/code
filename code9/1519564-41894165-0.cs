    static List<SomeObject> FilterObjects(List<SomeObject> objectList)
    {
    	int pos = 0;
    	bool closed = false;
    	for (int i = 0; i < objectList.Count; i++)
    	{
    		var item = objectList[i];
    
    		if (item.Status == "Finished")
    			return new List<SomeObject> { item };
    
    		if (item.Status == (closed ? "Opened" : "Closed"))
    		{
    			pos = i;
    			closed = !closed;
    		}
    	}
    	return objectList.GetRange(pos, closed ? 1 : objectList.Count - pos);
    }
