    IEnumerable<ViewModel> models = players.Select(p => new ViewModel()
    {
        PlayerName = p.PlayerName,
        Teams = String.Join("/", _db.PlayersInGame.Where(pg => pg.PlayerId == p.PlayerId).Select(pg => pg.TeamName))
    });
