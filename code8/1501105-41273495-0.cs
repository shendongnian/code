    matches.SelectMany(match => new[] {
        new TeamScore {
            TeamId = match.HomeId,
            Goals = match.Result.HomeTeamGoals
        },
        new TeamScore {
            TeamId = match.GuestId,
            Goals = match.Result.GuestTeamGoals
        }
    })
    .OrderByDescending(score => score.Goals)
    .First().TeamId;
