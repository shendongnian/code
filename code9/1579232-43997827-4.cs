    protected void AddPositionForPlayers(List<Player> players, List<Player> playerPosition)
    {
        players
            .ForEach(p => p.Position = 
                playerPosition.FirstOrDefault(pp => 
                   p.FirstName == pp.FirstName && p.LastName == pp.LastName && p.TeamName == pp.TeamName)
                ?.Position);
    }
