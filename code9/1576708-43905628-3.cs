    IEnumerable<ViewModel> models = _db.Players.Select(p => new ViewModel()
    {
        PlayerName = p.PlayerName,
        Teams = String.Join("/", _db.PlayersInGame.Where(pg => pg.PlayerId == p.PlayerId).Select(pg => pg.TeamName)),
        GameCount = _db.PlayersInGame.Count(pg => pg.PlayerId == p.PlayerId),
        NumberOfWins = _db.PlayersInGame.Where(pg => pg.PlayerId == p.PlayerId).Count(pg =>
        {
            Game game = _db.Games.Single(g => g.GameId == pg.GameId);
            bool isHome = game.HomeTeamId == pg.TeamId;
            return isHome ? (game.HomeTeamScore > game.AwayTeamScore) : (game.AwayTeamScore > game.HomeTeamScore);
        })
    });
