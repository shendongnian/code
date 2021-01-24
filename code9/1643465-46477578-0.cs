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
    
        // The problem is here: guess becomes equal to number -> while expression is true -> loop ends
        guess = Convert.ToInt32(Console.ReadLine());   
    }
