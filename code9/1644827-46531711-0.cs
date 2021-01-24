    ....
    List<char> newChars = new List<char>();
    foreach (char c in lower)
    {
    	int unicode = c;
    	int shiftUnicode = unicode + shift;
    	//Console.WriteLine(shiftUnicode);
    	if (shiftUnicode >= 123)
    	{
    		int overflowUnicode = 97 + (shiftUnicode - 123);
    		char character = (char)overflowUnicode;
    		newChars.Add(character);	
    	}
    	else
    	{
    		char character = (char)shiftUnicode;
    		newChars.Add(character);
    	}
    }
    string newString = new string(newChars.ToArray());
    Console.WriteLine(newString);
    ....
