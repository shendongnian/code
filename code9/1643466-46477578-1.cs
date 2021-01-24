    //declare variables
    int number = 4;
    int guessCount = 0;
    int guess;
    
    //get first number
    Console.WriteLine("Guess a number between 1 and 10:");
    // Problem A: user types in 4 -> guess becomes equal to number -> while expression gets false -> while body will not be executed
    guess = Convert.ToInt32(Console.ReadLine());
    while (guess != number) //keep repeating until number is chosen
    {
        guessCount = guessCount + 1; //increment counter
        if (guess < number) //if statement if guess is less than number
        {
            Console.WriteLine("Your guess is too low.");
        }
        else if (guess > number) //if statement if guess is more than number
        {
            Console.WriteLine("Your guess is too high.");
        }
        else //
        {
            Console.WriteLine("You got it!!");
        }
    
        //end of while to ask for a new guess
        Console.WriteLine("Guess again: ");
    
        // Problem B: user types in 4 -> guess becomes equal to number -> while expression gets false -> loop ends
        guess = Convert.ToInt32(Console.ReadLine());   
    }
