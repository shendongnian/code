    var result = dataContext.GetQueryable<PlayerGameResults>()
        .Where(player => player.Player.Id == testPlayerWithNoPlayedGames.Id)
        .Select(x => new {
            Name = x.Player.Name,
            Id = x.Player.Id,
        })
        .FirstOrDefault();
