    private static void Main()
    {
        // Players is a list of people playing, each of whom have
        // a list of hands (they may have more than one in the
        // case of a split), and each hand has a list of cards
        var players = new List<List<List<int>>>();
        var rnd = new Random();
        // Generate a random number of players and deal them each a card
        for (int i = 0; i < rnd.Next(1, 51); i++)
        {
            // Generate the first hand for each player (deal them each one card)
            {
                players.Add(new List<List<int>> {new List<int> {rnd.Next(1, 14)} });
            }
        }
        Console.WriteLine($"Welcome! We have {players.Count} playing today.");
        // Deal next card to each player, randomly split pairs, and finish each players hand
        foreach (var playerHands in players)
        {
            // Let player split as often as they can (continue to play
            // hands while they have a hand with one card in it)
            while (playerHands.Any(cardsInHand => cardsInHand.Count == 1))
            {
                foreach (var hand in playerHands.Where(cardsInHand => cardsInHand.Count == 1).ToList())
                {
                    var cardInHand = hand[0];
                    var drawnCard = rnd.Next(1, 14);
                    // I added this code to automatically give them a pair 25% of the time 
                    var forcePair = rnd.Next(1, 5) % 4 == 0; 
                    if (forcePair)
                    {
                        drawnCard = cardInHand;
                    }
                    if (drawnCard == cardInHand) // They drew a pair
                    {
                        // Randomly determine if they will split this hand
                        var splitThisHand = rnd.Next(1, 3) % 2 == 0; // If the number is even, we split
                        // Override random determination and always split on pairs
                        splitThisHand = true;
                        if (splitThisHand)
                        {
                            // Create a new hand for this player and add the card to it
                            playerHands.Add(new List<int> { drawnCard });
                        }
                        else
                        {
                            // Add the card to the existing hand
                            hand.Add(drawnCard);
                        }
                    }
                    else
                    {
                        // Add the card to the existing hand
                        hand.Add(drawnCard);
                    }
                }                    
            }
            // Finish playing each split hand
            foreach (var hand in playerHands)
            {
                var handValue = hand.Sum();
                    
                // hit if less than 17
                while (handValue < 17)
                {
                    var drawnCard = rnd.Next(1, 14);
                    hand.Add(drawnCard);
                    handValue += drawnCard;
                }
            }
        }
        // Output all the players statistics
        for (int i = 0; i < players.Count; i++)
        {
            var playerHands = players[i];
            Console.WriteLine($"Player #{i + 1} has {playerHands.Count} hands");
            for(int h = 0; h < playerHands.Count; h++)
            {
                var hand = playerHands[h];
                Console.WriteLine(
                    $" - Hand #{h + 1} has a value of {hand.Sum()}, containing the cards: {string.Join(", ", hand)}");                    
            }
        }
        Console.Write("\nDone!\nPress any key to quit.");
        Console.ReadKey();
    }
