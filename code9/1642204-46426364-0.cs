    var results = new int[6*diceCount + 1];
    // Will ignore indicies 0 to diceCount-1 as easier than using
    // non-zero based arrays.
    for (var roll = 1; roll <= rollCount; ++roll) {
      var rollResult = Enumerable.Range(0, diceCount)
                                 .Select(x => diceRandomGenerate.Next(1, 7))
                                 .Sum();
      results[rollResult]++;
    }
    for (var roll = diceCount; roll <= diceCount*6; ++roll) {
      Console.WriteLine($"{roll:d2} " + new String('*', results[roll]));
    }
