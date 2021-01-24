    var result = dataContext.GetQueryable<PlayerGameResults>()
        .Where(x => x.PlayedGame.Id == playedGameId && x.GameRank == -42)
        .Select(x => new AchievementRelatedPlayedGameSummary
        {
            WinningPlayerName = x.Player.Name,
            WinningPlayerId = x.Player.Id
        }).FirstOrDefault();
