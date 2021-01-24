    public static Driver ToDriver(this Team team,
        Dictionary<string, Team> allTeams,
        Func<Team, Driver> driverSelector)
    {
        Driver driver = driverSelector(team);
        if (driver.IsThere())
            return driver.Id;
        else
        {   // use allTeams:
            Team allternativeTeam = allTeams[team.Id];
            driver = friverSelector(alternativeTeam);
            if (driver.IsThere())
                return driver.Id;
            else
                throw new InvalidOperationException(...);
        }
    }
