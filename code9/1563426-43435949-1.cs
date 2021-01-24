	string userAnotherCard = Console.ReadLine();
	while (userAnotherCard == "y")
	{
	    Hands.playerHand.Add(Deck.CardDeck[Hands.rando.Next(0, Deck.CardDeck.Length)]);
	    Console.WriteLine("Your cards are: ");
	    Hands.playerHand.ForEach(Console.WriteLine);
	    Console.WriteLine("Would u like to take another card?");
	    userAnotherCard = Console.ReadLine();
        if (Hands.playerHand.Sum() > 21)
    	{
	        Console.WriteLine("You loss, your cards sum is more than 21");
	        break;
	    }
	}
	
