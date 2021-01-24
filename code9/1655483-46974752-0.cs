    public static bool IsValidPattern(string str)
    {
    	for (int i = 0; i < str.Length; i++)
    	{
    		if (char.IsLetter(str[i]))
    		{
    			if (i == 0 || i == str.Length - 1 || str[i - 1] != '+' || str[i + 1] != '+')
    			{
    				return false;
    			}
    		}
    	}
    
    	return true;
    }
