    protected void AddPositionForPlayers(List<Player> players, List<Player> playerPosition)
    {
        players
            .Select(p => p.TeamName = 
                playerPosition.FirstOrDefault(pp => 
                   p.FirstName == pp.FirstName && p.LastName == pp.LastName && p.TeamName == pp.TeamName)
                ?.TeamName);
    }
