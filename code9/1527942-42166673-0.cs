    public static Tuple<string, int[]> Encode(string key, string toEncrypt)
    {
    	key = key.ToLower();
    	int[] iterations = new int[] { 0, 0, 0, 0, 0, 0 };
    	if (key.Length % 2 == 0)
    	{ 
    		if (key.Length == key.Distinct().Count())
    		{
    			var encodedText = new StringBuilder(toEncrypt);
    			for (int i = 0; i < toEncrypt.Length ; i++)
    			{
    
    				for (int j = 0; j < key.Length; j += 2)
    				{
    
    					if (key[j] == toEncrypt[i])
    					{
    						encodedText[i] = key[j + 1];
    						iterations[j / 2] += 1;
    
    					}
    					else if (key[j+1] == toEncrypt[i])
    					{
    						encodedText[i] = key[j];
    						iterations[j / 2] += 1;
    					}
    				}
    			}
    
    			return Tuple.Create(encodedText.ToString(), iterations);
    		}
    		else throw new ArgumentException("Key cannot contain the same chars");
    	}
    	else throw new ArgumentException("You have to put a key which is dividable by 2");
    }
