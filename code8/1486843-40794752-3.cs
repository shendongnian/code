    var x = DoSomeGameLogic(diceRolls, out diceRolls);
    // or
    var x = DoSomeGameLogic(ref diceRolls);
    // or
    x = DoSomeGameLogic(diceRolls);
    diceRolls = x.RemainingDiceRolls;
