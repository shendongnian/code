    if (guesses < 15)
        Console.WriteLine("Guess a number between 1 and 9");
    string result = Console.ReadLine();
    guesses++;
    if (guesses > 15)
        Console.WriteLine("You went over 15 tries! Better luck next time");
