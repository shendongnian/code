    public static IEnumerable<string> ToDriverIds(this string teamId,
        Dictionary<string, Team> modifiedTeams
        Dictionary<string, Team> allTeams)
    {
        return modifiedTeams[teamId].ToDriverids(allTeams);
        // exception if there is no team with teamId
    }
