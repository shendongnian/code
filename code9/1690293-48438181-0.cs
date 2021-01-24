    if (playersToMoveUp.Count != 0)
    {
        foreach (var p in playersToMoveUp)
        {
            p.lp_pool_order = poolOrder;
        }
    }
    int tmpPoolSize = playersInPool + 1;
    foreach (var standing in standingsToPull)
    {
        standing.lp_standing = tmpPoolSize++;
    }
