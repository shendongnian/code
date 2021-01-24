    var q =
        from ctry in userLeagues.Select(ul => ul.Country).Distinct(new CountryComparer())
        select new
        {
            id = ctry.CountryID,
            name = ctry.Common_Name,
            leagues = userLeagues.Where(x => x.Country.CountryID == ctry.CountryID)
                                 .Select(x => new
                                 {
                                     id = x.LeagueID,
                                     name = x.leagueNameEn
                                 })
        };
