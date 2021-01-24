    foreach (var tournament in tournaments)
    {
        //// We take every team in every competitors to on Enumeration
        foreach (var team in tournament.Matches.SelectMany(match => match.Competitors.Teams))
        {
            team.CategoryId = tournament.CategoryId;
            team.Gender = tournament.Gender;
        }
    }
