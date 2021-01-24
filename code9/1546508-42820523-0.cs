    var result = dataContext.GetQueryable<PlayedGame>()
        .Where(player => player.Id == testPlayerWithNoPlayedGames.Id)
        .Select(x => new
        {
            Name = x.PlayerGameResults.FirstOrDefault().Player.Name,
            Id = (int?)x.PlayerGameResults.FirstOrDefault().Player.Id
        }).FirstOrDefault();
