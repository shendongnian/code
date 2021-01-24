    class Program1
    {
        static void Main(string[] args)
        {
            List<string>[] stringLists = new List<string>[3]
                {
                    new List<string>(){ "a", "b", "c" },
                    new List<string>(){ "e", "b", "c" },
                    new List<string>(){ "a", "b", "c" }
                };
    
            List<List<string>> prt = new List<List<string>>();
    		for(int i = 0; i < 3; i++)
    		{
    			bool isDifferentFromAllOthers = true;
    			for(int j = 0; j < i; j++)
    			{
    			    bool isSameAsThisItem = true;
    				for(int item = 0; item < 3; item++)
    				{
                        // !!! Here is the explicit item by item string comparison
    					if (stringLists[i][item] != stringLists[j][item])
    					{
    						isSameAsThisItem = false;
    						break;
    					}					
    				}
    				if (isSameAsThisItem)
    				{
    					isDifferentFromAllOthers = false;
    					break;
    				}
    			}
    			if (isDifferentFromAllOthers)
    			{
    				prt.Add(stringLists[i]);
    			}
    		}
    
    
    //        /* I DONT UNDERSTAND WHY THIS IS NOT WORKING !!!!!!!!!!!!!!! */
    //        foreach (var item in stringLists)
    //        {
    //            for (int i = 0; i < item.Count; i++)
    //            {
    //                if (item == stringLists[i] && (!prt.Contains(item)))
    //                {
    //                    prt.Add(item);
    //                }
    //            }
    //        }
        }
    }
