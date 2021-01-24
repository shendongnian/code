    while (true)
    {
        Console.Write("Enter your guess: ");
        string userGuess = Console.ReadLine().ToUpper();
        if (userGuess == "EXIT") return;
        int rowNumber;
        // Validate input
        if (userGuess.Length < 2 || userGuess.Length > 3)
        {
            Console.WriteLine("Guess must be in the form of ColumnRow, like: B5");
        }
        else if (!"ABCDEFGHIJ".Contains(userGuess[0]))
        {
            Console.WriteLine("Guess must begin with a valid column letter (A-J)");
        }
        else if (!int.TryParse(userGuess.Substring(1), out rowNumber)
                 || rowNumber < 1 || rowNumber > 10)
        {
            Console.WriteLine("Guess must end with a valid row number (1-10)");
        }
        else
        {
            // Valid input! Set actual indexes for the guess
            int colNumber = userGuess[0] - 65;
            rowNumber--;
            if (char.IsLetter(Grid[rowNumber, colNumber]))
            {
                Console.WriteLine("HIT!");
            }
            else
            {
                Console.WriteLine("MISS.");
            }
        }
    }
