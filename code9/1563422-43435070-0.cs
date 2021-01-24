                    Hands.playerHand.Add(Deck.CardDeck[Hands.rando.Next(0, Deck.CardDeck.Length)]);
                    Console.WriteLine("Your cards are: ");
                    Hands.playerHand.ForEach(Console.WriteLine);
                    Console.WriteLine("Would u like to take another card?");
                    Console.ReadLine();
                if (Hands.playerHand.Sum() > 22)
                {
                    Console.WriteLine("You loss, your cards sum is more than 21");
                    break;
                }
                 
            }
