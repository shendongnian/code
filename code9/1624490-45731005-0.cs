    public void SaveCharacters()
    {
        if (!NetworkServer.active)
            return;
    
        Database.SaveCharacters(Player.onlinePlayers.Values.ToList());
    }
    
    public void SaveCharacter(Player player)
    {
        Database.SaveCharacters(player);
    }
