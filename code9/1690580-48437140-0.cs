    static void Main(string[] args)
            {
                bool quit = false;
                int guesses = 5;
    
                while (!quit)
                {
                    Console.WriteLine("You are now playing 'Guess a Number'! The number is going to draw randomly from the range of 1 - 10. Enter the number you think the console drew and you have five chances to guess! Good luck!");
                    Random random = new Random();
                    bool guessingNumber = true;
                    
                    int randomNumber = random.Next(1, 10);
                    string playerGuess = Console.ReadLine();
                    List<int> num = new List<int>();
                    int oneNum;
                    if (int.TryParse(playerGuess, out oneNum))
                    {
                        num.Add(oneNum);
                    }
    
                    while (guessingNumber)
                    {
                        if (oneNum < randomNumber)
                        {
                            guesses--;
                            Console.WriteLine("The number you entered is smaller than the random number, you have {0} chances left.", guesses);
                            guessingNumber = false;
                            break;
                        }
    
                        if (oneNum > randomNumber)
                        {
                            guesses--;
                            Console.WriteLine("The number you entered is larger than the random number, you have {0} chances left.", guesses);
                            guessingNumber = false;
                        }
    
                        if (oneNum == randomNumber)
                        {
                            Console.WriteLine("Congratulations! You have guessed the right number!");
                            guessingNumber = false;
                        }
    
                        if (guesses == 0)
                        {
                            Console.WriteLine("Sorry, you have no more guesses.");
                            guessingNumber = false;
                        }
                    }
                }
            }
