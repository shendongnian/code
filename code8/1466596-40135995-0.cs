    public void Remove(int index) {
    	if(head != null)
    	{
    		if(index == 0)
    		{
    			head = head.next;
    		}
    		else
    		{
    			IntNode pos = head.next;
    			IntNode prev = head;
    			while (pos != null)
    			{
    				--index;
    				if (index == 0)
    				{
    					prev.next = pos.next;
    					break;
    				}
    				prev = pos;
    				pos = pos.next;
    			}
    		}
    	}
    }
