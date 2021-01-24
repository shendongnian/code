    int number = 4;
    int guesscount = 0;
    int guess;
    
    do {
        if (guesscount == 0) {
            Console.WriteLine("Guess a number between 1 and 10: ");
        } else {
            Console.WriteLine("Guess again: ");
        }
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
    } while (guess != number)
