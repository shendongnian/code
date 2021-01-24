    Console.Write("Please enter the number of dices you want to roll: ");
    string input = Console.ReadLine();
    while (input != "quit" && input != "exit")
    {
      int numTries = 0;
      if (int.tryParse(input, out numTries)
      {
        RollDice(numTries);
      }
      Console.Write("Please enter the number of dices you want to roll: ");
      input = Console.ReadLine();
    }
