    private static void InsertPlayer(PlayerModel player)
    {
        var server = db.EnsureGet(player.Region).EnsureGet(player.Server);
        PlayerModel existingPlayer;
        if (server.TryGetValue(player.Name, out existingPlayer))
        {
            //TODO: merge
        }
        else
            server[player.Name] = player;
    }
    public static T EnsureGet<T>(this Dictionary<string, T> dictionary, string key) where T : new()
    {
        T item;
        if (dictionary.TryGetValue(key, out item))
            return item;
        dictionary.Add(key, item = new T());
        return item;
    }
