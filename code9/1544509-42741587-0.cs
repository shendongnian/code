    var source = (from c in db.Standings
                 where c.LeagueID == leagueId
                 select new 
                 {
                     id = c.StandingsId,
                     team = c.Team
                 })
                 .ToList()
                 .Select(s => new Standing
                 {
                     id = s.id,
                     team = includeTeam ? c.Team.ToTeamDto("en-US") : null
                 });
