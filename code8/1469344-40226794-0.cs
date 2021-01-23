        string test = "hello";		
		List<string> lst = new List<string>();
		
		int charCount = 1;
		
		while (charCount <= test.Length)
		{
			lst.Add(string.Join("", test.Take(charCount).ToArray()));			
			charCount++;
		}
		
		string[] testing = lst.ToArray();
