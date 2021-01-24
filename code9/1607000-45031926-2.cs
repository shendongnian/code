    foreach (var tournament in tournaments)
    {
        SetMatchPropertiesFromTournament(tournament);
    }
    ...
    private void SetMatchPropertiesFromTournament(Tournament tournament)
    {
        foreach (var match in tournament.Matches)
        {
            match.SomeProperty = tournament.SomeProperty;
            foreach (var team in match.Competitors.Teams)
            {
                team.CategoryId = tournament.CategoryId;
                team.Gender = tournament.Gender;
                // and a few more here...
            }
        }
    }
