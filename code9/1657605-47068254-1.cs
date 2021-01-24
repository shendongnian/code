    using System;
    using System.Threading;
    
    namespace farino_HighLow
    {
        public class Game
        {
            // TAKES AND TRACKS USER INPUT
            public void PlayGame()
            {
                // CREATES VARIABLE FOR INPUT FROM THE USER (IF THEY MAKE AN INVALID GUESS OR WANT TO EXIT),
                // THE RANDOM VALUE GENERATED, THE USERS GUESS, AND A COUNTER FOR HOW MANY GUESSES THE USER TAKES
                Random random = new Random();
    
                int returnValue = random.Next(1, 100);
                string input;
                string line;
                int guess = 0;
                int count = 0;
    
                Console.Beep(1000, 2000);
    
                // INSTRUCTS USER WHAT TO DO
                Console.WriteLine("Guess a number between 1-100");
                Console.WriteLine("Hit Q at any time to exit the game");
    
                do
                {
                    input = Console.ReadLine();
    
                    try
                    {
                        guess = Convert.ToInt32(input);
                    }
                    catch
                    {
                        if (input == "Q")
                        {
                            //after press Q exit from application
                            return;
    
    
                        }
                    }
    
                    line = Console.ReadLine();
    
                    if (!int.TryParse(line, out guess))
                        Console.WriteLine("Not an integer!");
    
                    // MAKES SURE USER ENTERS A NUMBER WITHIN THE PARAMETERS OF THE GAME
                    // COUNTS THE USER GUESSES
                    // TELLS USER IF THEIR GUESS WAS RIGHT OR WRONG AND DIRECTS THEM TOWARDS A BETTER GUESS
                    if (guess >= 1 && guess <= 100)
                    {
                        if (guess > returnValue)
                        {
                            Console.Beep(100, 2000);
                            Console.WriteLine("Guess Again! Your guess is too HIGH");
                            count += 1;
                        }
                        if (guess < returnValue)
                        {
                            Console.Beep(300, 2000);
                            Console.WriteLine("Guess Again! Your guess is too LOW");
                            count += 1;
                        }
                        if (guess == returnValue)
                        {
                            Console.Beep(50, 2000);
                            Console.Beep(60, 2000);
                            Console.Beep(70, 2000);
                            Console.WriteLine("You got it RIGHT!!!!!!");
                            count += 1;
                            Console.WriteLine("It took you" + count + "guesses to win the game.");
                        }
                        if (guess < 1)
                        {
                            Console.WriteLine("That is not a valid entry");
                        }
                        if (guess > 100)
                        {
                            Console.WriteLine("That is not a valid entry");
                        }
                    }
                } while (guess != returnValue);
    
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
    }
