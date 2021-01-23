    List<int> GetTeamAncestors(Team team)
    {
        var ancestors = new List<int>(team.Id);
        while (team.Parent != null) // how do I know if the team has a parent?
        {
            team = team.Parent;
            ancestors.Add(team.Id);
        }
        return ancestors;
    }
