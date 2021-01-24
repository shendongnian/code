    public List<Race> AssignTargetTeamAndGetRaceList(Team source, Team target)
    {
        List<Race> raceList = new List<Race>();
        var races = source.Races
            .Where(race => !string.IsNullOrEmpty(race.Owner) && race.Owner == "Driver");
        foreach (Race r in races)
        {
            target.AddRace(r);
            Race newRace = new Race { Owner = "Codriver", Id = r.Id };
            newRace.SetTeam(r.Team);
        }
        return raceList;
    }
