        public static void Main(string[] args) {
            int number = 4;
            int guesscount = 1;
            int guess;
            string guessMessage;
            Console.WriteLine("Guess a number between 1 and 10: ");
            guess = GetNumber();
            while (guess != number) {
                if (guess < number) {
                    Console.WriteLine("Your guess is too low");
                }
                else if (guess > number) {
                    Console.WriteLine("Your guess is too high");
                }
                Console.WriteLine("Guess again: ");
                guess = GetNumber();
                guesscount++;
            }
            if (guesscount == 1)
                guessMessage = "Well done!!! You got it first time!";
            else 
                guessMessage = "You got it!! It took " + guesscount + " guesses.";
           
            Console.WriteLine(guessMessage);
            Console.ReadLine();
        }
        private static int GetNumber() {
            int number;
            while (!Int32.TryParse(Console.ReadLine(), out number)) {
                Console.WriteLine("That was not a number!\nGuess again: ");
            }
            return number;
        }
