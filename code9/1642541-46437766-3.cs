            int number = 4;
            int guessCount = 1;
            int guess;
            string guessMessage;
            Console.WriteLine("Guess a number between 1 and 10: ");
            guess = Convert.ToInt32(Console.ReadLine());
            while (guess != number) {
                if (guess < number) {
                    Console.WriteLine("Your guess is too low");
                }
                else if (guess > number) {
                    Console.WriteLine("Your guess is too high");
                }
                Console.WriteLine("Guess again: ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;
            }
            if (guessCount == 1)
                guessMessage = "Well done!!! You got it first time!";
            else 
                guessMessage = "You got it!! It took " + guesscount + " guesses.";
           
            Console.WriteLine(guessMessage);
            Console.ReadLine();
