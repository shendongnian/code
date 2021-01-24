    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Blackjack
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Creating array
                string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
                string[] cards = new string[13];
                cards[0] = "A";
                cards[1] = "2";
                cards[2] = "3";
                cards[3] = "4";
                cards[4] = "5";
                cards[5] = "6";
                cards[6] = "7";
                cards[7] = "8";
                cards[8] = "9";
                cards[9] = "10";
                cards[10] = "J";
                cards[11] = "Q";
                cards[12] = "K";
                int dealer_total = 0;
                int player_total = 0;
                int blackjack = 21;
                // Dealing 2 player cards, then calculating and outputting card value
                Random r = new Random();
                for (int i = 0; i < 2; i++)
                {
                    int suit = r.Next(0, 4);
                    int card = r.Next(0, 13);
                    string suit_name = suits[suit];
                    string card_name = cards[card];
                    string full_name = card_name + " of " + suit_name;
                    Console.WriteLine(full_name);
                    int cardValue = getcardvalue(card_name);
                    player_total = player_total + cardValue;
                    Console.WriteLine("You have a total of " + player_total); // Prints player's card value
                }
                bool hit = true;
                while (hit)
                {
                    Console.WriteLine("Would you like to stick or hit?");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "stick")
                    {
                        hit = false;
                        // Dealing dealer cards
                        for (int i = 0; i < 2; i++)
                        {
                            int suit = r.Next(0, 4);
                            int card = r.Next(0, 13);
                            string suit_name = suits[suit];
                            string card_name = cards[card];
                            string full_name = card_name + " of " + suit_name;
                            int cardValue = getcardvalue(card_name);
                            dealer_total = dealer_total + cardValue;
                            Console.WriteLine("Dealer has a total of " + dealer_total);
                            if (dealer_total > player_total)
                            {
                                Console.WriteLine("Dealer wins, you lose.");
                            }
                            else if ((player_total) > (dealer_total))
                            {
                                Console.WriteLine("You win!");
                            }
                            else
                            {
                                Console.WriteLine("Dealer total matches your total, draw.");
                            }
                        }
                    }
                    // if player chooses to hit, another card is drawn
                    else if (input.ToLower() == "hit")
                    {
                        int suit = r.Next(0, 4);
                        int card = r.Next(0, 13);
                        string suit_name = suits[suit];
                        string card_name = cards[card];
                        string full_name = card_name + " of " + suit_name;
                        Console.WriteLine(full_name);
                        int cardValue = getcardvalue(card_name);
                        player_total = player_total + cardValue;
                        Console.WriteLine("You have a total of " + player_total);
                        if (player_total > 21)
                        {
                            Console.WriteLine("You are bust; you lose.");
                            hit = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid response. Please choose either stick or hit.");
                        // Outputs an error message if anything else is input
                    }
                }
            }
            private static int getcardvalue(string card_name)
            {
                int card_value = 0;
                if (card_name == "A") // ie if the card is an Ace
                {
                    card_value = 11;
                }
                else if (card_name == "K" || card_name == "Q" || card_name == "J") // if the card is a face card
                {
                    card_value = 10;
                }
                else
                {
                    card_value = int.Parse(card_name); //if the card is any other card, then it is worth its pip value
                }
                return card_value;
            }
        }
    }
