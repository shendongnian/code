    Regex pattern;
    
    // Get Full Name
    Console.Write("Enter your name for the card: ");
    pattern = new Regex(@"\b[a-zA-Z]{2,15}\s[a-zA-Z]{2,15}\b");
    string name = Convert.ToString(Console.ReadLine());
    if (pattern.IsMatch(name))
    {
    	// Do a thing with name
    	Console.WriteLine("Name was valid");
    }
    else
    {
    	// Name not valid. Do a thing.
    	Console.WriteLine("Name was not valid");
    }
    
    // Get Credit Card Number
    Console.Write("Enter your credit card number: ");
    string card = Convert.ToString(Console.ReadLine());
    pattern = new Regex("^[0-9]{12,19}$");
    if (pattern.IsMatch(card))
    {
    	// Do a thing with card
    	Console.WriteLine("Card was valid");
    }
    else
    {
    	// Card not valid. Do a thing.
    	Console.WriteLine("Card was not valid");
    }
    
    Console.WriteLine("Thank-you for ordering. ");
