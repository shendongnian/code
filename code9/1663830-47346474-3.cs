    public static IEnumerable<string> ToDriverIds(this Team,
       Dictionary<string, Team> allTeams)
    {
        // return the driverId of the driver:
        yield return Team.ToDriverId(allTeams, team => team.Driver);
        // yield return the driverId of the CoDriver:
        yield return Team.ToDriverId(allTeams, team => team.CoDriver);
    }
