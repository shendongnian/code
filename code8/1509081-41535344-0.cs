    Game gameToJoin = null;
    if(queItem.RequestedMap == null)
    {
         gameToJoin = db.Games
                        .Where(x => x.Map.Id == queItem.RequestedMap.Id)
                        .FirstOrDefault;
    }
