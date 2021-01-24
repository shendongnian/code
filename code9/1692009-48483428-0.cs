    static void Main(string[] args)
    {
    	Console.WriteLine("Welcome to the Caesarian Cipher program");
    	Console.WriteLine("Please, enter a word.");
    
    	string word = Console.ReadLine();
    
    	char[] letters = word.ToCharArray(); //chops the string up into individual characters.
    
    	// USING FOR LOOP
    	int shift=3;
    	for (int i = 0; i < letters.Length; i++)
    	{
    		// Letter.
    		char letter = word[i];
    		// Add shift to all.
    		letter = (char)(letter + shift);
    		// Subtract 26 on overflow.
    		// Add 26 on underflow.
    		if (letter > 'z')
    		{
    			letter = (char)(letter - 26);
    		}
    		else if (letter < 'a')
    		{
    			letter = (char)(letter + 26);
    		}
    		Console.WriteLine(letter);
    	}
    	
    	//USING FOREACH LOOP
    
    
    	
    }
