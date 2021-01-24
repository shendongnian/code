    static void Main(string[] args)
        {
            bool quit = false;
            Random random = new Random();
            int randomNumber = random.Next(1, 10);
            Console.WriteLine("You are now playing 'Guess a Number'! The number is going to draw randomly from the range of 1 - 10. Enter the number you think the console drew and you have five chances to guess! Good luck!");
            List<int> num = new List<int>();
            int guesses = 5;
            while (!quit)
            {
                string playerGuess = Console.ReadLine();
                int oneNum;
                if (int.TryParse(playerGuess, out oneNum))
                {
                    num.Add(oneNum);
                }
                var lastNum = num.Last();
                if (guesses == 0) //the guesses times should be checked first.
                {
                    Console.WriteLine("Sorry, you have no more guesses.");
                    break;
                }
                if (lastNum < randomNumber)//the list's last element was your input number.
                {
                    guesses--;
                    Console.WriteLine("The number you entered is smaller than the random number, you have {0} chances left.", guesses);
                }
                if (lastNum > randomNumber)
                {
                    guesses--;
                    Console.WriteLine("The number you entered is bigger than the random number, you have {0} chances left.", guesses);
                }
                if (lastNum==randomNumber)//if  equals
                {
                    quit = true;//set the flag to end loop
                    Console.WriteLine("Congratulations! You have guessed the right number!");
                }
            }
            Console.ReadKey();
        }
