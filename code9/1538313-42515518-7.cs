    var cc = new CountryComparer();
    var q =
        from ctry in userLeagues.Select(ul => ul.Country).Distinct(cc)
        select new
        {
            id = ctry.CountryID,
            name = ctry.Common_Name,
            leagues = userLeagues.Where(x => cc.Equals(x.Country, ctry))
                                 .Select(x => new
                                 {
                                     id = x.LeagueID,
                                     name = x.leagueNameEn
                                 }).ToList()
        };
