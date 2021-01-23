    class Program
    {
        public static int SelectedNumber = 0;
        public static Random ran = new Random();
        public static bool GameOver = false;
        public static int UserMaxValue = 0;
        static void Main(string[] args)
        {
            int UserNumber;
            SelectedNumber = ran.Next(0, UserMaxValue);
            do
            {
                Console.WriteLine("Enter a max number you want to guess from!");
                UserMaxValue = Convert.ToInt32(Console.ReadLine());
            do
                {
                    Console.WriteLine("Select a number between 1 and {0}!", UserMaxValue);
                    UserNumber = Convert.ToInt32(Console.ReadLine());
                    GuessNumber(UserNumber);
            } while (GameOver == false);
            } while (GameOver == false);
        }
        public static void GuessNumber(int UserNumber)
        {
            int playagain = 0;
            if (UserNumber < SelectedNumber)
                Console.WriteLine("Your Number is Wrong! Please try Again!");
            else if (UserNumber > SelectedNumber)
                Console.WriteLine("Your Number is Wrong! Please Try Again!");
            else
            {
                Console.WriteLine("Yay! You got the right number! Press 1 to play again press 2 to quit");
                playagain = Convert.ToInt32(Console.ReadLine());
                while (playagain != 1 && playagain != 2)
                {
                    Console.WriteLine("Please Only Select 1 to play again or 2 to quit!");
                    playagain = Convert.ToInt32(Console.ReadLine());
                }
                if (playagain.Equals(2))
                    GameOver = true;
                else
                    SelectedNumber = ran.Next(0, UserMaxValue);
            }
        }
    }
}
