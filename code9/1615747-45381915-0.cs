       public static class myClass
        {
            public static int GetObjectIndexFromTitle<T>(T myList, string myString)
            {
    			foreach (var item in myList)
    			{
    				if (item.Title == myString)
    				{
    					return list.IndexOf(item);
    				}
    			}
    			return -1;
            }
    	}
    
