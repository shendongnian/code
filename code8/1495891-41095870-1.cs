    int numOfRolls = 20;
    List<Pair> playerOneRolls = Enumerable.Range(0, numOfRolls).Select(n => Pair.RollNewPair()).ToList();
    List<Pair> playerTwoRolls = Enumerable.Range(0, numOfRolls).Select(n => Pair.RollNewPair()).ToList();
    foreach (var roll in playerOneRolls.Except(playerTwoRolls))
    {
        // do whatever
    }
