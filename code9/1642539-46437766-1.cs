            int number = 4;
            int guesscount = 0;
            int guess;
            Console.WriteLine("Guess a number between 1 and 10: ");
            guess = Convert.ToInt32(Console.ReadLine());
            while (guess != number) {
                guesscount = guesscount + 1;
                if (guess < number) {
                    Console.WriteLine("Your guess is too low");
                }
                else if (guess > number) {
                    Console.WriteLine("Your guess is too high");
                }
                Console.WriteLine("Guess again: ");
                guess = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("You got it!!");
            Console.ReadLine();
