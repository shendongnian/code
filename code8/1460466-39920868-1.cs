    public void ScanMessage(string filename)
    {
    	spamCount = 0;
    	spamProbability = 0.0;
    
    	var messageRead="";
    	using(var input = new StreamReader(filename))
    	{
    		messageRead = input.ReadToEnd();
    	}
    	//Converts message to lowercase
    	messageRead = messageRead.ToLower();
    
    	//For each word in spam phrases, look through the message. If a spam phrase is found,
    	//increment spamCount and add it to the sorteddictionary, or adds an entry to the
    	//sortedDictionary if it already exists
    	foreach (var word in spamPhrases)
    	{
    		if (messageRead.Contains(word))
    		{
    			spamCount++;
    			messageSpamPhrases.Add(word, 1);
    		}
    	}
    
    	spamProbability = spamCount / 30.0 * 100.0;
    
    	//This is for the list of spam phrases found
    	phrasesFound = new String[messageSpamPhrases.Count() + 1];
    	phrasesFound[0] = string.Format("{0,-22}{1,-12}\n", "Phrase", "Count");
    	int x = 1;
    
    	foreach (String key in messageSpamPhrases.Keys)
    	{
    		phrasesFound[x++] = String.Format("{0,-25} {1,-25}", key, messageSpamPhrases[key]);
    	}
    
    	//The message of probability of spam
    	spamResult = String.Format("This message has a {0}% chance of being a spam message", spamProbability);
    }
