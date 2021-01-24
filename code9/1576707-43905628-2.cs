    IEnumerable<ViewModel> models = players.Select(p => new ViewModel()
    {
        PlayerName = p.PlayerName,
        Teams = String.Join("/", _db.PlayersInGame.Where(pg => pg.PlayerId == p.PlayerId).Select(pg => pg.TeamName)),
        GameCount = _db.PlayersInGame.Count(pg => pg.PlayerId == p.PlayerId),
        NumberOfWins = _db.PlayersInGame.Where(pg => pg.PlayerId == p.PlayerId).Count(pg =>
        {
            Game g = _db.Games.Single(g => g.GameId == pg.GameId);
            bool isHome = g.HomeTeamId == pg.TeamId;
            return isHome ? (g.HomeTeamScore > g.AwayTeamScore) : (g.AwayTeamScore > g.HomeTeamScore);
        })
    });
