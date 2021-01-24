    int number = 4;
    int guesscount = 0;
    int guess;
    
    Console.WriteLine("Guess a number between 1 and 10: ");    
    do {
        guesscount = guesscount + 1;
        guess = Convert.ToInt32(Console.ReadLine());
        Console.ReadLine();
        if (guess < number)
        {
            Console.WriteLine("Your guess is too low");
        }
        else if (guess > number)
        {
            Console.WriteLine("Your guess is too high");
        }
        else
        {
            Console.WriteLine("You got it!!");
        }
        Console.WriteLine("Guess again: ");
    } while (guess != number)
