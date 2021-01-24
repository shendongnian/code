            static string FindFirst(int length, string stringpair)
    		{
    			var set = new HashSet<string>();
    			for (int i = 0; i < stringpair.Length; i++)
    			{
    				string subStr = stringpair.Substring(i, length);
    
    				if (set.Contains(subStr)) // if contains, then there is already 1 key with same value
    					return subStr;
    
    				set.Add(subStr);
    			}
    			return null;
    		}
