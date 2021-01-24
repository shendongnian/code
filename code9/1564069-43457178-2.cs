    // Get Full Name
    string name = "";
    while (!Regex.IsMatch(name, @"\b[a-zA-Z]{2,15}\s[a-zA-Z]{2,15}\b"))
    {
    	Console.Write("Enter your name for the card (Firstname Lastname): ");
    	name = Console.ReadLine();
    }
    
    // Get Credit Card Number
    string card = "";
    while (!Regex.IsMatch(card, "^[0-9]{12,19}$"))
    {
    	Console.Write("Enter your credit card number: ");
    	card = Console.ReadLine();
    }
    
    Console.WriteLine("Thank-you for ordering. ");
    Console.Read();
