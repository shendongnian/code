    var scienceSubjects = new HashSet<string> { "GK", "PHY", "CHE", "BIO" };
    
    using(var db = new DBContext()) 
    {
        var resultQuery = db.ScoreInfos
                            .Select(scoreInfo => new 
                            {
                                ScoreInfo = scoreInfo,
                                GrpId = scienceSubjects.Contains(scoreInfo.Subject) ? 0 : 1
                            })
                            .OrderByDescending(x=>x.GrpId)
                            .ThenByDescending(x=>x.ScoreInfo.Score)
                            .Select(x=>x.ScoreInfo)
                            .Take(5);
    }
