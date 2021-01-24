            while (true)
            {
                Console.WriteLine("Would u like to take another card?");
                string userAnotherCard = Console.ReadLine();
                bool secondHand = true;
                secondHand = (userAnotherCard == "y");
                bool secondHandNo = true;
                secondHandNo = (userAnotherCard == "n");
                if (secondHand)
                {
                    Hands.playerHand.Add(Deck.CardDeck[Hands.rando.Next(0, Deck.CardDeck.Length)]);
                    Console.WriteLine("Your cards are: ");
                    Hands.playerHand.ForEach(Console.WriteLine);
                }
                if (Hands.playerHand.Sum() > 21)
                {
                    Console.WriteLine("You loss, your cards sum is more than 21");
                    break;
                }
                if (secondHandNo)
                    break;
            }
