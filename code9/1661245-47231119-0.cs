            public static void FoundTreasure(int guessColumn, int guessRow )
        {
            if (Math.Abs(guessRow - TRow) == 0 && Math.Abs(guessColumn - TColumn) == 0)
            {
                Console.WriteLine("You got it...");
                return;
            }
            if (Math.Abs(guessRow - TRow) <= 1 && Math.Abs(guessColumn <= TColumn) <= 1)
            {
                Console.WriteLine("You are hot...");
                return;
            }
            Console.WriteLine("You are cold...");
        }
