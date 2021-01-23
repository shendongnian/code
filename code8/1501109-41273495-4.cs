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
    .GroupBy(score => score.Goals)
    .OrderByDescending(group => group.Key)
    .First()
    .Select(score => score.TeamId);
