		IDictionary<string, int> actualDictionary = new Dictionary<string, int>();
		
        foreach (string word in userText) //search words in our array userText that we declared at the beginning.
        {
			if (!actualDictionary.ContainsKey(word)) {
				actualDictionary[word] = 0;
			}
			
			actualDictionary[word]++;
        }
		
		foreach(var thing in actualDictionary) {
		    Console.WriteLine(thing.Key + " " + thing.Value);
		}
