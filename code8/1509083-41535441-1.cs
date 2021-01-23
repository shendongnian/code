    var gameToJoin = db.Games.AsQueryable();
    // add the where's that always need to be checked.
    if (queItem.RequestMap != null)
    {
        gameToJoin = gameToJoin.Where(x => x.Map.Id = queItem.RequestMap.Id);
    }
    var result = gameToJoin.ToList();
