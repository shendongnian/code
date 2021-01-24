    static int Search(string[] list, string elementSought)
    {
    		for (int i = 0; i < list.Length; i++)
    		{
    			if (list[i] == elementSought)
    			{
    				Console.WriteLine($"Item {elementSought} found");
    				return i;
    			}
    		}
    
    		return -1;
    }
 
