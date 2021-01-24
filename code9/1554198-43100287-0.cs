    var res2 = dbEntity.tbl_Match.Select(m => new
                {
                    MatchID = m.MatchID,
                    Team1 = m.Team1,
                    Team2 = m.Team2,
                    UserForTeam1 = dbEntity.tbl_UserBets.FirstOrDefault(b => b.UserForTeam1 == userID && b.MatchID == m.MatchID),
                    UserForTeam2 = dbEntity.tbl_UserBets.FirstOrDefault(b => b.UserForTeam2 == userID && b.MatchID == m.MatchID)
                });
