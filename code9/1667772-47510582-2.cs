    public void AssignTargetRaces(Team source, Team target)
    {
        var races = source.Races.Where(race => !string.IsNullOrEmpty(race.Owner) && race.Owner == "Driver");
        foreach (Race r in races)
            target.AddRace(new Race(r) {Owner = "Codriver"});
    }
