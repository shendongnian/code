    IEnumerable<ViewModel> models = players.Select(p => new ViewModel()
    {
        PlayerName = p.Name,
        Teams = String.Join("/", _db.PlayersInGame.Where(pg => pg.PlayerId == p.Id).Select(pg => pg.TeamName)),
        GameCount = _db.PlayersInGame.Count(pg => pg.PlayerId == p.Id)
    });
