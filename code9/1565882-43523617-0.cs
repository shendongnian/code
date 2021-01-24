    // Removed "Random dice = new Random(); "
    public int RollDice(Random dice)
    {
        int dice1 = dice.Next(1, 7);
        int dice2 = dice.Next(1, 7);
        int sum = dice1 + dice2;
        Console.WriteLine("D1: " + dice1 + " D2: " + dice2 + " SUM: " + sum);
        return sum;
    }
    // Main
    var dice = new Random();
    while (true) 
    {
        player1.RollDice(dice);
        Console.ReadKey();
        player2.RollDice(dice);
    }
