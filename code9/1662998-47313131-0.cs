     Console.WriteLine("\nBeggining credit balance = " + initialBalance);
     Console.WriteLine("\nPlease place a bet. You will lose those credits for every incorrect guess!");
     bet = int.Parse(Console.ReadLine());
     runningBalance = initialBalance
     do
     {
         Console.WriteLine("\nGuess a number between 1 and 100.");
         userGuess = Convert.ToInt32(Console.ReadLine());
         numGuesses++;
    
         UI output = new UI();
         output.CompareNumbers(userGuess, ref selectedNumber, ref playAgain, ref numGuesses);
    
    
         runningCredits -= bet;
         Console.WriteLine("\nYou have " + runningCredits + " credits remaining.");
    
     } while (playAgain == true);
