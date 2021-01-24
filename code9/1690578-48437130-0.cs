    while (guessingNumber)
    {
        playerGuess = Console.ReadLine();
        if (int.TryParse(playerGuess, out oneNum))
        {
            num.Add(oneNum);
        }
        ...
