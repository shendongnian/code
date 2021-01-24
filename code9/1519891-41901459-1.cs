        const int iMaxGuesses = 15;
        const int iListSize = 5;
        static void Main(string[] args)
        {
            Random myRandom = new Random();
            // Hold a list of integers
            List<int> numbers = new List<int>();
            int guesses = 0;
            
            // Value where we will rebuild the code
            string result = string.Empty;
            // Placeholder for user's guess
            string strGuess;
            
            // Converted guess
            int guess;
            // Generate random list of numbers
            for (int i = 0; i < iListSize; i++)
                numbers.Add(myRandom.Next(1, 10));
            // Prompt user
            Console.WriteLine("Guess the {0} Digit code, Under {1} tries!", iListSize, iMaxGuesses);
            // Open the game loop
            do
            {
                // Check if we have exceeded the max amount of times we get to guess
                if (guesses > iMaxGuesses)
                    Console.WriteLine("You went over 15 tries! Better luck next time");
                else
                {
                    // Prompt user
                    Console.WriteLine("Guess a number between 1 and 9");
                    // Get input
                    strGuess = Console.ReadLine();
                    // Check if input is in fact an integer, if so - put the value in our variable 'guess'
                    if (int.TryParse(strGuess, out guess))
                    {
                        // We have a proper guess, increment
                        guesses++;
                        // Checks if the number is the next in our list
                        if (numbers[0] == guess)
                        {
                            Console.WriteLine("Congratulations, {0} was a match!", guess);
                            // Remove that from the List
                            numbers.Remove(numbers[0]);
                            // Add it to our sequence (result)
                            result += guess;
                        }
                    }
                    else // Inform user we will only accept numbered input
                        Console.WriteLine("That was not a number.  Please try again!");
                }
            } while (guesses <= iMaxGuesses && numbers.Count > 0);
            if (guesses < iMaxGuesses)
                Console.WriteLine("Correct! It took {0} guesses to come up with the pattern {1}", guesses, result);
            else
                Console.WriteLine("You took to many tries! Better luck next time! Total Guesses: {0}", guesses);
            Console.ReadLine();
        }
