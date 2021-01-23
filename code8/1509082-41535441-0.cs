    var gameToJoin = db.Games;
    if (queItem.RequestMap != null)
    {
        gameToJoin = gameToJoin.Where(x => x.Map.Id = queItem.RequestMap.Id);
    }
    var result = gameToJoin.FirstOrDefault();
