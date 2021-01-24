    ProcessItem(Item item)
    {
    	if(item.prop == "somevalue")
    	{
    		lock(_list)
    		{
    			_list.Add(item);
    		}
    	}
    }
