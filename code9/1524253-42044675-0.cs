    private IEnumerable<string> EnumerateLetters()
    {
    	int count = 1;
    	while (true)
    	{
    		foreach(var letters in EnumerateLetters(count))
    		{
    			yield return letters;
    		}
    		count++;
    	}
    }
    
    private IEnumerable<string> EnumerateLetters(int count)
    {
    	if (count==0)
    	{
    		yield return String.Empty;
    	}
    	else
    	{
    		char letter = 'A';	
    		while(letter<='Z')
    		{
    			foreach(var letters in EnumerateLetters(count-1))
    			{
    				yield return letter+letters;
    			}
    			letter++;
    		}
    	}
    }
