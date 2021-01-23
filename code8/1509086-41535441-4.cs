    var gameToJoin = db.Games.AsQueryable();
    // add the where's that always need to be checked.
    if (queItem.RequestMap != null)
    {
        var result = new List<Game>();
        var game = gameToJoin.FirstOrDefault(x => x.Map.Id = queItem.RequestMap.Id);
        if (game != null)
        {
           result.Add(game);
        }
        return result;
    }
    return gameToJoin.ToList();
