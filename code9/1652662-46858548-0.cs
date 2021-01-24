    public void RemoveNegative(Point data)
    {
    	if (data != null)
    	{
    		Point previous = data;
    		Point current = data.Next;
    
    		while (current != null)
    		{
    			if (current.Value < 0)
    			{
    				previous.Next = current.Next;
    			}
    			else
    			{
    				previous = current;
    			}
    
    			current = previous.Next;
    		}
    	}
    }
