    // Game class has teamData list/array:
    List<Game> games = new List<Game>();
    // ... Populate games
    foreach (var game in games) {
      var g0 = game.teamData[0].currentGoals, g1 = game.teamData[1].currentGoals;
      if (g0 > g1) {
        game.teamData[0].teamWins++;;
        game.teamData[1].teamLosses++;
      }
      else if (g1 > g0) {
        game.teamData[1].teamWins++;;
        game.teamData[0].teamLosses++;
      }
      else {
        game.teamData[0].teamDraws++;
        game.teamData[1].teamDraws++;
      }
    }
