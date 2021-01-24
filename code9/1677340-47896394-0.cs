    private static void Main(string[] args)
        {
            Random rnd = new Random();
            bool gamerunning = false;
            while (gamerunning == false)
            {
                int roll1 = rnd.Next(1, 7);
                int roll2 = rnd.Next(1, 7);
                int roll3 = rnd.Next(1, 7);
                int roll4 = rnd.Next(1, 7);
                int roll5 = rnd.Next(1, 7);
                int roll6 = rnd.Next(1, 7);
                int roll7 = rnd.Next(1, 7);
                int roll8 = rnd.Next(1, 7);
                int roll9 = rnd.Next(1, 7);
                int roll10 = rnd.Next(1, 7);
                int roll11 = rnd.Next(1, 7);
                int roll12 = rnd.Next(1, 7);
                int Player1Total = roll1 + roll2 + roll3;
                int Player2Total = roll4 + roll5 + roll6;
                int Player1Total2roll = roll7 + roll8;
                int Player2Total2roll = roll9 + roll10;
                int P1froll = roll11;
                int P2froll = roll12;
                int overallP1 = Player1Total + Player1Total2roll + P1froll;
                int overallP2 = Player2Total + Player2Total2roll + P2froll;
                int Player1Score = 0;
                int Player2Score = 0;
                Console.WriteLine("Press anything to roll your die");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\nPlayer1 first dice is ", roll1);
                Console.WriteLine("Player1 second dice is " + roll2);
                Console.WriteLine("Player1 third dice is " + roll3);
                Console.WriteLine("Your total is " + Player1Total);
                Console.WriteLine("\nYour opponents first dice roll is " + roll4);
                Console.WriteLine("Your opponents second dice roll is " + roll5);
                Console.WriteLine("Your opponents third dice roll is " + roll6);
                Console.WriteLine("Your opponents total is " + Player2Total);
                Console.WriteLine("\nPlayer1 first dice is " + roll7);
                Console.WriteLine("Player1 second dice is " + roll8);
                Console.WriteLine("Your total is " + Player1Total2roll);
                Console.WriteLine("\nYour opponents first dice roll is " + roll9);
                Console.WriteLine("Your opponents second dice roll is " + roll10);
                Console.WriteLine("Your total is " + Player2Total2roll);
                Console.WriteLine("\nPlayer1 final roll is " + roll11);
                Console.WriteLine("Your total is " + P1froll);
                Console.WriteLine("\nYour opponents final roll is " + roll12);
                Console.WriteLine("Your total is " + P2froll);
                if (overallP1 > overallP2)
                {
                    Player1Score++;
                    Console.WriteLine("\nPlayer 1 Wins");
                    Console.WriteLine("The Current Score is:");
                    Console.WriteLine("Player 1: " + Player1Score);
                    Console.WriteLine("Player 2: " + Player2Score);
                }
                else if (overallP2 > overallP1)
                {
                    Player2Score++;
                    Console.WriteLine("\nPlayer 2 Wins");
                    Console.WriteLine("The Current Score is:");
                    Console.WriteLine("Player 1: " + Player1Score);
                    Console.WriteLine("Player 2: " + Player2Score);
                }
                if (overallP1 == overallP2)
                    Console.WriteLine("\nIt's a draw");
                if (Player1Score >= 5)
                    gamerunning = true;
                else if (Player2Score >= 5)
                    gamerunning = true;
                //if ( Player1Score == Player2Score)
                //{
                //    DiceRoll();
                //}
            }
        }
