    public void AssignValues(Team source, Team target)
    {
        var races = source.Races
            .Where(race => !string.IsNullOrEmpty(race.Owner) && race.Owner == "Driver")
            .Select(x => new Race 
            {
                Id = x.Id,
                Owner = x.Owner
            }
            .ToList();
        races.ForEach(race => 
        { 
            race.Owner = "Codriver"; 
            target.AddRace(race); 
        });
    }
