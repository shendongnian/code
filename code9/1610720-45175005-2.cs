    // Asks the user to guess; returns true if the user guessed correctly.
    private static bool Guess(int answer)
    {
      int playerGuess = GetIntegerFromUser("What is your guess?");
      // TODO: write GetIntegerFromUser
      if (playerGuess > answer)
      {
        Console.WriteLine("Your number was too high!");
        return false;
      }
      else if (playerGuess < answer)
      {
        Console.WriteLine("Your number was too small!");
        return false;
      }
      else
      {
        Console.WriteLine("You win!");
        return true;
      }
    }
