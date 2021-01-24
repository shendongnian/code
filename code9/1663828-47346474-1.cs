    public static IEnumerable<string> ToDriverIds(this Team team,
        Dictionary<string, Team> allTeams)
    {
        if (team.Driver.IsThere())
            // Driver is there, yield return the Id
            yield return team.Driver.DriverId;
        else
        {   // Driver not available, fetch the Driver from allTeams
            // throw exception if there is no alternative team with this team ID
            Team alternativeTeam = allTeams[team.Id];
            if (alternativeTeam.IsDriverThere())
                yield return alternativeTeam.Driver.Id;
            else
               // Driver also not in alternative team: exception
               throw new InvalidOperationException("...");
            // do the same for coDriver
        }
    }
 
