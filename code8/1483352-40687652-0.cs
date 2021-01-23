    public object GetMatchupByVideoId(int id)
    {
        var videoMatchup = _DBContext.Matchups
            .Where(m => m.VideoID == id)
            .Select(m => new {
                ID = m.VideoID,
                Players = m.Players.Select(p => new {
                    ID = p.PlayerID,
                    User = p.User,
                    Character = p.Character,
                    Outcome = p.Outcome
                })
            });
        return videoMatchup;
    }
