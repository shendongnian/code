    class Program
    {
        public static int SelectedNumber = 0;
        public static Random ran = new Random();
        public static bool GameOver = false;
        public static int UserMaxValue = 0;
        public static string decision;
        static void Main(string[] args)
        {
            int UserNumber = 0;
            bool playAgain = false;
            do
            {
                Console.WriteLine("What is the maximum number you want to guess from?");
                UserMaxValue = Convert.ToInt32(Console.ReadLine());
                SelectedNumber = ran.Next(1, UserMaxValue); // Re-assign SelectedNumber for every new max number input. Random number start changed to 1 to avoid 0 value for SelectedNumber
                do
                {
                    Console.WriteLine("Select a number between 1 and {0}!", UserMaxValue);
                    UserNumber = Convert.ToInt32(Console.ReadLine());
                    playAgain = GuessNumber(UserNumber);
                    // I changed GameOver to see if the guessing portion is finished or not
                } while (!GameOver); // You don't need to use GameOver == false
            } while (playAgain); // Check if user wants to play again or not
        }
        public static bool GuessNumber(int UserNumber)
        {
            GameOver = false;
            if (UserNumber < SelectedNumber)
            {
                Console.WriteLine("Your number is wrong, please try again!");
            }
            else if (UserNumber > SelectedNumber)
            {
                Console.WriteLine("Your Number is wrong, please try again!");
            }
            else
            {
                GameOver = true;
                Console.WriteLine("Yay! You got the right number. Do you want to play again? (y/n) ", decision);
                decision = Console.ReadLine();
                if (decision == "n")
                {
                    return false;
                }
                // I removed redundant code
            }
            return true;
        }
    }
