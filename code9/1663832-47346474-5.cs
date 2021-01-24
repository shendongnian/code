    public static IEnumerable<string> ToIds(this IEnumerable<string> teamIds,
       IEnumerable<Team> modifiedTeams, IEnumerable<Team> allTeams)
    {
        var modifiedTeamsLookup = modifiedTeams.ToDictionary(team => team.Id);
        var allTeamsLookup = allTeams.ToDictionary(team => team.Id);
        return teamIds
            .SelectMany(teamId => teamId.ToDriverIds(modifiedTeamsLookup,
                allTeamsLookup);
        
    }
