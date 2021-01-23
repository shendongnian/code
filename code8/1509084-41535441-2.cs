    var result = new List<Game>();
    var gameToJoin = db.Games.AsQueryable();
    // add the where's that always need to be checked.
    if (queItem.RequestMap != null)
    {
        var game = gameToJoin.FirstOrDefault(x => x.Map.Id = queItem.RequestMap.Id);
        if (game != null)
        {
           result.Add(game);
        }
    }
    else
    {
        result.AddRange(gameToJoin.ToList());
    }
    return result;
