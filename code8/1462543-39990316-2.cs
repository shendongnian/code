    class Program
    {
        public static int SelectedNumber = 0;
        public static Random ran = new Random();
        public static bool GameOver = false;
        public static int UserMaxValue = 0;        
        static void Main(string[] args)
        {
            int UserNumber = 0;
            bool playAgain = false;
            do
            {
                bool isUserMaxValueValid = false;
                do
                {
                    Console.WriteLine("What is the maximum number you want to guess from?");
                    isUserMaxValueValid = int.TryParse(Console.ReadLine(), out UserMaxValue);
                } while (!isUserMaxValueValid);
                SelectedNumber = ran.Next(1, UserMaxValue); // Re-assign SelectedNumber for every new max number input. Random number start changed to 1 to avoid 0 value for SelectedNumber
                do
                {
                    bool isUserNumberValid = false;
                    do
                    {
                        Console.WriteLine("Select a number between 1 and {0}!", UserMaxValue);
                        isUserNumberValid = int.TryParse(Console.ReadLine(), out UserNumber);
                    } while (!isUserNumberValid);
                    playAgain = GuessNumber(UserNumber);
                    // I changed GameOver to see if the guessing portion is finished or not
                } while (!GameOver); // You don't need to use GameOver == false
            } while (playAgain); // Check if user wants to play again or not
        }
        public static bool GuessNumber(int UserNumber)
        {
            if (UserNumber != SelectedNumber)
            {
                GameOver = false;
                Console.WriteLine("Your number is wrong, please try again!");
            }
            else
            {
                GameOver = true;
                bool isPlayAgainValid = false;
                Console.WriteLine("Yay! You got the right number. Do you want to play again? (y/n)");
                do
                {
                    string decision = Console.ReadLine();
                    if (decision.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }
                    else if (decision.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                    if(!isPlayAgainValid)
                    {
                        Console.WriteLine("Please enter y or n only.");
                    }
                } while (!isPlayAgainValid);               
                
                // I removed redundant code
            }
            return true;
        }
    }
