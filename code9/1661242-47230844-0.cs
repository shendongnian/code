     if (Math.Abs(guessRow - tRow) == 1 || Math.Abs(guessColumn - tColumn) == 1)
            {
                Console.WriteLine("You are hot...");
            }
            else if (Math.Abs(guessRow - tRow) == 0 && Math.Abs(guessColumn - tColumn) == 0)
            {
                Console.WriteLine("You got it...");
            }
            else
            {
                Console.WriteLine("You are cold...");
            }
