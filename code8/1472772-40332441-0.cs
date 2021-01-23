        char theCharacter;
        string userInput;
        char[] allowedChars=new char[]{'a','b','c'};
        do {
            Console.WriteLine("Please choose a valid character(a, b or c).");
        	userInput=Console.ReadLine();
        } while(!char.TryParse(userInput, out theCharacter)||!allowedChars.Contains(theCharacter));
