     dbEntity.tbl_Match.Select(m => new{
         m.Id,
        Team1Name=dbEntity.TournamentTeams.SingleOrDefault(t => t.id=m.Team1).Name,
        Team2Name =dbEntity.TournamentTeams.SingleOrDefault(t => t.id=m.Team2).Name
         })
